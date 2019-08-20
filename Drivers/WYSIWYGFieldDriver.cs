using Etch.OrchardCore.EditorJS.Fields;
using Etch.OrchardCore.EditorJS.Parsers;
using Etch.OrchardCore.EditorJS.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;

namespace Etch.OrchardCore.EditorJS.Drivers
{
    public class WYSIWYGFieldDriver : ContentFieldDisplayDriver<WYSIWYGField>
    {
        #region Dependencies

        private readonly IBlocksParser _blocksParser;

        #endregion

        #region Constructor

        public WYSIWYGFieldDriver(IBlocksParser blocksParser)
        {
            _blocksParser = blocksParser;
        }

        #endregion

        public override IDisplayResult Display(WYSIWYGField field, BuildFieldDisplayContext context)
        {
            return Initialize<DisplayWYSIWYGFieldViewModel>(GetDisplayShapeType(context), model =>
            {
                model.Field = field;
                model.Part = context.ContentPart;
                model.PartFieldDefinition = context.PartFieldDefinition;
                model.Html = field.Html;
            })
            .Location("Content")
            .Location("SummaryAdmin", "")
            .Location("DetailAdmin", "");
        }

        public override IDisplayResult Edit(WYSIWYGField field, BuildFieldEditorContext context)
        {
            return Initialize<EditWYSIWYGFieldViewModel>(GetEditorShapeType(context), model =>
            {
                model.Field = field;
                model.Part = context.ContentPart;
                model.PartFieldDefinition = context.PartFieldDefinition;
                model.Data = field.Data;
            });
        }

        public override async Task<IDisplayResult> UpdateAsync(WYSIWYGField field, IUpdateModel updater, UpdateFieldEditorContext context)
        {
            if (await updater.TryUpdateModelAsync(field, Prefix, f => f.Data))
            {
                field.Html = _blocksParser.ToHtml(field.Data);
            }

            return Edit(field, context);
        }
    }
}
