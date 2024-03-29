﻿using Etch.OrchardCore.Blocks.EditorJS.Parsers.Models;
using Etch.OrchardCore.Blocks.ViewModels.Blocks;
using Fluid.Values;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Blocks.EditorJS.Parsers.Blocks
{
    public class RawBlockParser : IBlockParser
    {
        public async Task<dynamic> RenderAsync(BlockParserContext context, Block block)
        {
            return await context.ShapeFactory.New.Block__Raw(
                new RawBlockViewModel
                {
                    Html = await context.LiquidTemplateManager.RenderStringAsync(block.Get("html"), HtmlEncoder.Default, block, new Dictionary<string, FluidValue>() { ["ContentItem"] = new ObjectValue(context.ContentItem) })
                }
            );
        }
    }
}
