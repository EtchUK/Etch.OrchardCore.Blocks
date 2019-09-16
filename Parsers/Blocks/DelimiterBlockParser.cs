using Etch.OrchardCore.Blocks.Parsers.Models;

namespace Etch.OrchardCore.Blocks.Parsers.Blocks
{
    public class DelimiterBlockParser : IBlockParser
    {
        public string Render(Block block)
        {
            return "<hr />";
        }
    }
}
