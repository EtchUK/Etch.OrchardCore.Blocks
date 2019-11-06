﻿using Etch.OrchardCore.Blocks.Fields;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Blocks.Settings
{
    public class BlockFieldSettingsDriver : ContentPartFieldDefinitionDisplayDriver<BlockField>
    {
        public override IDisplayResult Edit(ContentPartFieldDefinition partFieldDefinition)
        {
            return Initialize<BlockFieldSettings>("BlockFieldSettings_Edit", model => partFieldDefinition.Settings.Populate(model))
                .Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentPartFieldDefinition partFieldDefinition, UpdatePartFieldEditorContext context)
        {
            var model = new BlockFieldSettings();

            await context.Updater.TryUpdateModelAsync(model, Prefix);

            context.Builder.MergeSettings(model);
            context.Builder.WithSetting(nameof(BlockFieldSettings.LinkableContentTypes), model.LinkableContentTypes);

            return Edit(partFieldDefinition);
        }
    }
}