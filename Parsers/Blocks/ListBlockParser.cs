using Etch.OrchardCore.Blocks.Parsers.Models;
using Newtonsoft.Json.Linq;
using System;

namespace Etch.OrchardCore.Blocks.Parsers.Blocks
{
    public class ListBlockParser : IBlockParser
    {
        public string Render(Block block)
        {
            var tag = block.Data["style"].ToString() == "unordered" ? "ul" : "ol";
            var items = (block.Data["items"] as JArray).ToObject<string[]>();

            var html = $"<{tag}>";

            foreach (var item in items)
            {
                html += $"{Environment.NewLine}\t<li>{item}</li>";
            }

            html += $"{Environment.NewLine}</{tag}>";
            return html;
        }
    }
}
