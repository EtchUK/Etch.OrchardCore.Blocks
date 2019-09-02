using Etch.OrchardCore.EditorJS.Parsers.Models;
using System;

namespace Etch.OrchardCore.EditorJS.Parsers.Blocks
{
    public class QuoteBlockParser : IBlockParser
    {
        public string Render(Block block)
        {
            var cssClasses = (block.Data.ContainsKey("alignment") && block.Data["alignment"] as string == "center") ? "blockquote blockquote--centered" : "blockquote";
            var html = $"<blockquote class=\"{cssClasses}\">";

            html += $"{Environment.NewLine}\t<p>{block.Data["text"]}</p>";

            if (block.Data.ContainsKey("caption") && !string.IsNullOrWhiteSpace((string)block.Data["caption"]))
            {
                html += $"{Environment.NewLine}\t<footer>{block.Data["caption"]}</footer>";
            }

            html += $"{Environment.NewLine}</blockquote>";
            return html;
        }
    }
}
