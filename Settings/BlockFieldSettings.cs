using System;

namespace Etch.OrchardCore.Blocks.Settings
{
    public class BlockFieldSettings
    {
        public string[] LinkableContentTypes { get; set; } = Array.Empty<string>();

        public string Placeholder { get; set; }
    }
}
