using Etch.OrchardCore.EditorJS.Fields;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;

namespace Etch.OrchardCore.EditorJS.ViewModels
{
    public class EditWYSIWYGFieldViewModel
    {
        public WYSIWYGField Field { get; set; }
        public ContentPart Part { get; set; }
        public ContentPartFieldDefinition PartFieldDefinition { get; set; }

        public string Data { get; set; }
    }
}
