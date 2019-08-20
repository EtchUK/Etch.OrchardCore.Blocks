using Etch.OrchardCore.EditorJS.Parsers.Models;

namespace Etch.OrchardCore.EditorJS.Parsers.Blocks
{
    public interface IBlockParser
    {
        string Render(Block block);
    }
}
