using Etch.OrchardCore.Blocks.EditorJS.Parsers.Blocks;
using Etch.OrchardCore.Blocks.Parsers;
using Fluid;
using Fluid.Values;
using Newtonsoft.Json.Linq;
using OrchardCore.ContentManagement;
using OrchardCore.Liquid;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Blocks.Filters
{
    public class BlocksBuildDisplayFilter : ILiquidFilter
    {
        private readonly IBlocksParser _blocksParser;

        public BlocksBuildDisplayFilter(IBlocksParser blocksParser) => _blocksParser = blocksParser;

        public async ValueTask<FluidValue> ProcessAsync(FluidValue input, FilterArguments arguments, LiquidTemplateContext context)
        {
            var data = input.ToStringValue();
            ContentItem contentItem = null;

            if (arguments.Names.Contains("contentItem"))
            {
                var obj = arguments["contentItem"].ToObjectValue();

                if (!(obj is ContentItem))
                {
                    contentItem = null;

                    if (obj is JObject jObject)
                    {
                        contentItem = jObject.ToObject<ContentItem>();
                    }
                }
            }

            return FluidValue.Create(await _blocksParser.RenderAsync(data, contentItem), context.Options);
        }
    }
}
