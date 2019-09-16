using System;
using Etch.OrchardCore.Blocks.Parsers.Models;

namespace Etch.OrchardCore.Blocks.Parsers.Blocks
{
    public class EmbedBlockParser : IBlockParser
    {
        public string Render(Block block)
        {
            var html = $"<div class=\"embed embed--{block.Data["service"]}\">";
            html += $"{Environment.NewLine}\t<iframe src=\"{block.Data["embed"]}\" frameborder=\"0\" allow=\"autoplay; encrypted-media\" allowfullscreen></iframe>";
            html += $"{Environment.NewLine}</div>";

            if (block.Data.ContainsKey("caption") && !string.IsNullOrWhiteSpace((string)block.Data["caption"]))
            {
                html += $"{Environment.NewLine}\t<p>{block.Data["caption"]}</p>";
            }

            return html;
        }
    }
}
