using Etch.OrchardCore.Blocks.EditorJS.Parsers.Models;
using Etch.OrchardCore.Blocks.ViewModels.Blocks;
using OrchardCore.DisplayManagement;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Blocks.EditorJS.Parsers.Blocks
{
    public class RawBlockParser : IBlockParser
    {
        public async Task<dynamic> RenderAsync(IShapeFactory shapeFactory, Block block)
        {
            return await shapeFactory.New.Block__Raw(
                new RawBlockViewModel
                {
                    Html = block.Get("html")
                }
            ); ;
        }
    }
}
