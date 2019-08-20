using Newtonsoft.Json;
using System.Collections.Generic;

namespace Etch.OrchardCore.EditorJS.Parsers.Models
{
    public class Block
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("data")]
        public IDictionary<string, object> Data { get; set; }
    }
}
