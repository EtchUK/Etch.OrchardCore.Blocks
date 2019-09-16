using Etch.OrchardCore.Blocks.Parsers.Models;

namespace Etch.OrchardCore.Blocks.Parsers.Blocks
{
    public class RawBlockParser : IBlockParser
    {
        public string Render(Block block)
        {
            return (string)block.Data["html"];
        }
    }
}
