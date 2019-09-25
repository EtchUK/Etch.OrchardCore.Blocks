using System;
using System.Threading.Tasks;
using Etch.OrchardCore.Blocks.EditorJS.Parsers.Models;
using Etch.OrchardCore.Blocks.ViewModels.Blocks;
using OrchardCore.DisplayManagement;

namespace Etch.OrchardCore.Blocks.EditorJS.Parsers.Blocks
{
    public class EmbedBlockParser : IBlockParser
    {
        public async Task<dynamic> RenderAsync(IShapeFactory shapeFactory, Block block)
        {
            return await shapeFactory.New.Block__Embed(
                new EmbedBlockViewModel
                {
                    Caption = block.Get("caption"),
                    Service = block.Get("service"),
                    SourceUrl = block.Get("embed")
                }
            );
        }
    }
}
