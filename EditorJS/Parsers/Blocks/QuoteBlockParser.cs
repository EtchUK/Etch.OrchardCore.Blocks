using Etch.OrchardCore.Blocks.EditorJS.Parsers.Models;
using Etch.OrchardCore.Blocks.ViewModels.Blocks;
using OrchardCore.DisplayManagement;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Blocks.EditorJS.Parsers.Blocks
{
    public class QuoteBlockParser : IBlockParser
    {
        public async Task<dynamic> RenderAsync(IShapeFactory shapeFactory, Block block)
        {
            return await shapeFactory.New.Block__Quote(
                new QuoteBlockViewModel
                {
                    Alignment = block.Get("alignment"),
                    Caption = block.Get("caption"),
                    Text = block.Get("text")
                }
            );
        }
    }
}
