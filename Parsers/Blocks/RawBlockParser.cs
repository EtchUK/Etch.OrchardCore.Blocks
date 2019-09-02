using Etch.OrchardCore.EditorJS.Parsers.Models;

namespace Etch.OrchardCore.EditorJS.Parsers.Blocks
{
    public class RawBlockParser : IBlockParser
    {
        public string Render(Block block)
        {
            return (string)block.Data["html"];
        }
    }
}
