﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Etch.OrchardCore.Blocks.EditorJS.Parsers.Models
{
    public class Block
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("data")]
        public IDictionary<string, object> Data { get; set; }

        public string Get(string property)
        {
            return Data[property]?.ToString() ?? string.Empty;
        }

        public bool Has(string property)
        {
            return Data.ContainsKey(property);
        }
    }
}
