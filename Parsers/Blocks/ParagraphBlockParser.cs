using Etch.OrchardCore.EditorJS.Parsers.Models;

namespace Etch.OrchardCore.EditorJS.Parsers.Blocks
{
    public class ParagraphBlockParser : IBlockParser
    {
        public string Render(Block block)
        {
            return $"<p>{block.Data["text"]}</p>";
        }
    }
}
