using Etch.OrchardCore.Blocks.EditorJS.Parsers.Models;

namespace Etch.OrchardCore.Blocks.EditorJS.Parsers.Blocks
{
    public class HeadingBlockParser : IBlockParser
    {
        public string Render(Block block)
        {
            return $"<h{block.Data["level"]}>{block.Data["text"]}</h{block.Data["level"]}>";
        }
    }
}
