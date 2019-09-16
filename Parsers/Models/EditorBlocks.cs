using Newtonsoft.Json;
using System.Collections.Generic;

namespace Etch.OrchardCore.Blocks.Parsers.Models
{
    public class EditorBlocks
    {
        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("blocks")]
        public IList<Block> Blocks { get; set; }
    }
}
