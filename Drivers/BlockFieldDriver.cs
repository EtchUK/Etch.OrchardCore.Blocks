using Etch.OrchardCore.Blocks.Fields;
using Etch.OrchardCore.Blocks.Parsers;
using Etch.OrchardCore.Blocks.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Blocks.Drivers
{
    public class BlockFieldDriver : ContentFieldDisplayDriver<BlockField>
    {
        #region Dependencies

        private readonly IBlocksParser _blocksParser;

        #endregion

        #region Constructor

        public BlockFieldDriver(IBlocksParser blocksParser)
        {
            _blocksParser = blocksParser;
        }

        #endregion

        public override IDisplayResult Display(BlockField field, BuildFieldDisplayContext context)
        {
            return Initialize<DisplayBlockFieldViewModel>(GetDisplayShapeType(context), model =>
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

        public override IDisplayResult Edit(BlockField field, BuildFieldEditorContext context)
        {
            return Initialize<EditBlockFieldViewModel>(GetEditorShapeType(context), model =>
            {
                model.Field = field;
                model.Part = context.ContentPart;
                model.PartFieldDefinition = context.PartFieldDefinition;
                model.Data = field.Data;
            });
        }

        public override async Task<IDisplayResult> UpdateAsync(BlockField field, IUpdateModel updater, UpdateFieldEditorContext context)
        {
            if (await updater.TryUpdateModelAsync(field, Prefix, f => f.Data))
            {
                field.Html = _blocksParser.ToHtml(field.Data);
            }

            return Edit(field, context);
        }
    }
}
