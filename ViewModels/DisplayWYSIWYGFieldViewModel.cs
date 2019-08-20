using Etch.OrchardCore.EditorJS.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;

namespace Etch.OrchardCore.EditorJS.ViewModels
{
    public class DisplayWYSIWYGFieldViewModel
    {
        public WYSIWYGField Field { get; set; }
        public ContentPart Part { get; set; }
        public ContentPartFieldDefinition PartFieldDefinition { get; set; }

        public string Html { get; set; }
    }
}
