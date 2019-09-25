using Etch.OrchardCore.Blocks.EditorJS.Parsers.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Etch.OrchardCore.Blocks.EditorJS.Parsers.Blocks
{
    public class ImageParser : IBlockParser
    {
        public string Render(Block block)
        {
            var items = (block.Data["media"] as JArray).ToObject<ImageBlockMediaItem[]>();
            var html = string.Empty;

            foreach (var item in items)
            {
                html += $"<figure>";

                html += $"{Environment.NewLine}\t<img src=\"{item.Url}\" />";

                if (!string.IsNullOrWhiteSpace(item.Caption))
                {
                    html += $"{Environment.NewLine}\t<figcaption>{item.Caption}</figcaption>";
                }

                html += $"{Environment.NewLine}</figure>{Environment.NewLine}{Environment.NewLine}";
            }
            return html;
        }

        private class ImageBlockMediaItem
        {
            [JsonProperty("caption")]
            public string Caption { get; set; }

            [JsonProperty("mediaPath")]
            public string MediaPath { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }
        }
    }
}