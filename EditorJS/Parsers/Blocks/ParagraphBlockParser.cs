using Etch.OrchardCore.Blocks.EditorJS.Parsers.Models;

namespace Etch.OrchardCore.Blocks.EditorJS.Parsers.Blocks
{
    public class ParagraphBlockParser : IBlockParser
    {
        public string Render(Block block)
        {
            return $"<p>{block.Data["text"]}</p>";
        }
    }
}
