using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Blocks
{
    public class Migrations : DataMigration
    {
        #region Dependencies

        private readonly IContentDefinitionManager _contentDefinitionManager;

        #endregion

        #region Constructor

        public Migrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        #endregion

        #region Migrations

        public async Task<int> CreateAsync()
        {
            await _contentDefinitionManager.AlterPartDefinitionAsync("BlockBodyPart", builder => builder
                .Attachable()
                .Reusable()
                .WithDisplayName("Block Body")
                .WithDescription("Provides rich text editor for curating content for body of content item.")
                .WithDefaultPosition("5")
            );

            return 1;
        }

        #endregion
    }
}
