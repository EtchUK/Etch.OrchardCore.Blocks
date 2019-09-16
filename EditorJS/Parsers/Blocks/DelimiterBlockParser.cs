using Etch.OrchardCore.Blocks.EditorJS.Parsers.Models;

namespace Etch.OrchardCore.Blocks.EditorJS.Parsers.Blocks
{
    public class DelimiterBlockParser : IBlockParser
    {
        public string Render(Block block)
        {
            return "<hr />";
        }
    }
}
