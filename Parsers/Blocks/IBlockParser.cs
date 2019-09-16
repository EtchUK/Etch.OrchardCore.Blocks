using Etch.OrchardCore.Blocks.Parsers.Models;

namespace Etch.OrchardCore.Blocks.Parsers.Blocks
{
    public interface IBlockParser
    {
        string Render(Block block);
    }
}
