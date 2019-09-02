using Etch.OrchardCore.EditorJS.Parsers.Models;

namespace Etch.OrchardCore.EditorJS.Parsers.Blocks
{
    public class DelimiterBlockParser : IBlockParser
    {
        public string Render(Block block)
        {
            return "<hr />";
        }
    }
}
