using Etch.OrchardCore.Blocks.Parsers.Models;

namespace Etch.OrchardCore.Blocks.Parsers.Blocks
{
    public class ParagraphBlockParser : IBlockParser
    {
        public string Render(Block block)
        {
            return $"<p>{block.Data["text"]}</p>";
        }
    }
}
