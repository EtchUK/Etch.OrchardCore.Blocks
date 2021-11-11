using Etch.OrchardCore.Blocks.Settings;
using System;

namespace Etch.OrchardCore.Blocks.ViewModels
{
    public class BlockBodyPartSettingsViewModel
    {
        public string[] LinkableContentTypes { get; set; } = Array.Empty<string>();
        public string Placeholder { get; set; }

        public BlockBodyPartSettings BlockBodyPartSettings { get; set; }
    }
}
