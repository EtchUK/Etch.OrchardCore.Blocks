using Etch.OrchardCore.Blocks.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;

namespace Etch.OrchardCore.Blocks.ViewModels
{
    public class DisplayBlockFieldViewModel
    {
        public BlockField Field { get; set; }
        public ContentPart Part { get; set; }
        public ContentPartFieldDefinition PartFieldDefinition { get; set; }

        public string Html { get; set; }
    }
}
