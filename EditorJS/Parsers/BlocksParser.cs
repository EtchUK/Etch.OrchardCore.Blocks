using Etch.OrchardCore.Blocks.EditorJS.Parsers.Blocks;
using Etch.OrchardCore.Blocks.EditorJS.Parsers.Models;
using Etch.OrchardCore.Blocks.Fields;
using Etch.OrchardCore.Blocks.Models;
using Etch.OrchardCore.Blocks.Parsers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrchardCore.DisplayManagement;
using OrchardCore.Liquid;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Blocks.EditorJS.Parsers
{
    public class BlocksParser : IBlocksParser
    {
        #region Properties

        private IDictionary<string, IBlockParser> _parsers = new Dictionary<string, IBlockParser>
        {
            { Constants.DelimiterBlock, new DelimiterBlockParser() },
            { Constants.EmbedBlock, new EmbedBlockParser() },
            { Constants.HeaderBlock, new HeadingBlockParser() },
            { Constants.ImageBlock, new ImageParser() },
            { Constants.ListBlock, new ListBlockParser() },
            { Constants.ParagraphBlock, new ParagraphBlockParser() },
            { Constants.QuoteBlock, new QuoteBlockParser() },
            { Constants.RawBlock, new RawBlockParser() }
        };

        #endregion Properties

        #region Dependencies

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILiquidTemplateManager _liquidTemplateManager;
        private readonly ILogger<BlocksParser> _logger;
        private readonly IShapeFactory _shapeFactory;

        #endregion Dependencies

        #region Constructor

        public BlocksParser(IHttpContextAccessor httpContextAccessor, ILiquidTemplateManager liquidTemplateManager, ILogger<BlocksParser> logger, IShapeFactory shapeFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _liquidTemplateManager = liquidTemplateManager;
            _logger = logger;
            _shapeFactory = shapeFactory;
        }

        #endregion Constructor

        #region Implementation

        public async Task<IList<dynamic>> RenderAsync(BlockField field)
        {
            return await RenderAsync(new BlockParserContext
            {
                ContentItem = field.ContentItem,
                HttpContext = _httpContextAccessor.HttpContext,
                LiquidTemplateManager = _liquidTemplateManager,
                ShapeFactory = _shapeFactory
            }, field.Data);
        }

        public async Task<IList<dynamic>> RenderAsync(BlockBodyPart part)
        {
            return await RenderAsync(new BlockParserContext
            {
                ContentItem = part.ContentItem,
                HttpContext = _httpContextAccessor.HttpContext,
                LiquidTemplateManager = _liquidTemplateManager,
                ShapeFactory = _shapeFactory
            }, part.Data);
        }

        #endregion Implementation

        #region Private Methods

        public async Task<IList<dynamic>> RenderAsync(BlockParserContext context, string data)
        {
            var shapes = new List<dynamic>();

            foreach (var block in JsonConvert.DeserializeObject<EditorBlocks>(data).Blocks)
            {
                if (!_parsers.ContainsKey(block.Type))
                {
                    continue;
                }

                try
                {
                    shapes.Add(await _parsers[block.Type].RenderAsync(context, block));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Failed to render {block.Type} block.");
                }
            }

            return shapes;
        }

        #endregion Private Methods
    }
}