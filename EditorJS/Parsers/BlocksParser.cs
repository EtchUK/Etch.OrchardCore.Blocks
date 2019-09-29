using Etch.OrchardCore.Blocks.EditorJS.Parsers.Blocks;
using Etch.OrchardCore.Blocks.EditorJS.Parsers.Models;
using Etch.OrchardCore.Blocks.Fields;
using Etch.OrchardCore.Blocks.Parsers;
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
            { "delimiter", new DelimiterBlockParser() },
            { "embed", new EmbedBlockParser() },
            { "header", new HeadingBlockParser() },
            { "image", new ImageParser() },
            { "list", new ListBlockParser() },
            { "paragraph", new ParagraphBlockParser() },
            { "quote", new QuoteBlockParser() },
            { "raw", new RawBlockParser() }
        };

        #endregion

        #region Dependencies

        private readonly ILiquidTemplateManager _liquidTemplateManager;
        private readonly ILogger<BlocksParser> _logger;
        private readonly IShapeFactory _shapeFactory;

        #endregion

        #region Constructor

        public BlocksParser(ILiquidTemplateManager liquidTemplateManager, ILogger<BlocksParser> logger, IShapeFactory shapeFactory)
        {
            _liquidTemplateManager = liquidTemplateManager;
            _logger = logger;
            _shapeFactory = shapeFactory;
        }

        #endregion

        #region Implementation

        public async Task<IList<dynamic>> RenderAsync(BlockField field)
        {
            var shapes = new List<dynamic>();

            var context = new BlockParserContext
            {
                Field = field,
                LiquidTemplateManager = _liquidTemplateManager,
                ShapeFactory = _shapeFactory
            };

            foreach (var block in JsonConvert.DeserializeObject<EditorBlocks>(field.Data).Blocks)
            {
                if (!_parsers.ContainsKey(block.Type))
                {
                    continue;
                }

                try
                {
                    shapes.Add(await _parsers[block.Type].RenderAsync(context, block));
                } catch (Exception ex)
                {
                    _logger.LogError(ex, $"Failed to render {block.Type} block.");
                }
            }

            return shapes;
        }

        #endregion
    }
}
