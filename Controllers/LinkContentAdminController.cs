using Etch.OrchardCore.Blocks.Services;
using Etch.OrchardCore.Blocks.Settings;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.Admin;
using OrchardCore.ContentManagement.Metadata;
using System.Linq;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Blocks.Controllers
{
    [Admin]
    public class LinkContentAdminController : Controller
    {
        #region Dependencies

        private readonly IContentDefinitionManager _contentDefinitionManager;
        private readonly IContentSearchResultsProvider _contentSearchResultsProvider;

        #endregion

        #region Constructor

        public LinkContentAdminController(IContentDefinitionManager contentDefinitionManager, IContentSearchResultsProvider contentSearchResultsProvider)
        {
            _contentDefinitionManager = contentDefinitionManager;
            _contentSearchResultsProvider = contentSearchResultsProvider;
        }

        #endregion

        #region Actions

        public async Task<IActionResult> SearchContentItems(string part, string field, string query)
        {
            if (string.IsNullOrWhiteSpace(part) || string.IsNullOrWhiteSpace(field))
            {
                return BadRequest("Part and field are required parameters");
            }

            var partFieldDefinition = _contentDefinitionManager.GetPartDefinition(part)?.Fields
                .FirstOrDefault(f => f.Name == field);

            var fieldSettings = partFieldDefinition?.Settings.ToObject<BlockFieldSettings>();
            if (fieldSettings == null)
            {
                return BadRequest("Unable to find field definition");
            }

            var results = await _contentSearchResultsProvider.SearchAsync(new ContentSearchContext
            {
                ContentTypes = fieldSettings.LinkableContentTypes,
                Query = query
            });

            return new ObjectResult(results);
        }

        #endregion
    }
}
