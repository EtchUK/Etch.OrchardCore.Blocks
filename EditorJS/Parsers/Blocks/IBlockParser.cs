using Etch.OrchardCore.Blocks.EditorJS.Parsers.Models;
using OrchardCore.DisplayManagement;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Blocks.EditorJS.Parsers.Blocks
{
    public interface IBlockParser
    {
        Task<dynamic> RenderAsync(IShapeFactory shapeFactory, Block block);
    }
}
