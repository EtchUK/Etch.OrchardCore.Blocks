using Etch.OrchardCore.Blocks.EditorJS.Parsers.Models;
using OrchardCore.DisplayManagement;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Blocks.EditorJS.Parsers.Blocks
{
    public class DelimiterBlockParser : IBlockParser
    {
        public async Task<dynamic> RenderAsync(IShapeFactory shapeFactory, Block block)
        {
            return await shapeFactory.New.Block__Delimiter();
        }
    }
}
