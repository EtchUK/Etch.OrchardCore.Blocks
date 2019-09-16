using Etch.OrchardCore.Blocks.EditorJS.Parsers.Models;

namespace Etch.OrchardCore.Blocks.EditorJS.Parsers.Blocks
{
    public interface IBlockParser
    {
        string Render(Block block);
    }
}
