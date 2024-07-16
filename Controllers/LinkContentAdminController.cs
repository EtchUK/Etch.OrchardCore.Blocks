using Etch.OrchardCore.Blocks.Services;
using Etch.OrchardCore.Blocks.Settings;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.Admin;
using OrchardCore.ContentManagement.Metadata;
using System;
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrWhiteSpace(part))
            {
                return BadRequest("Part is required parameter");
            }

            try
            {
                var linkableTypes = await GetLinkableTypesAsync(part, field);
                return new ObjectResult(await _contentSearchResultsProvider.SearchAsync(new ContentSearchContext
                {
                    ContentTypes = linkableTypes,
                    Query = query
                }));
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Private Methods

        private async Task<string[]> GetLinkableTypesAsync(string part, string field)
        {
            var linkableTypes = await GetLinkableTypesFromFieldDefinitionAsync(part, field);
            if (!string.IsNullOrEmpty(field))
            {                
                return linkableTypes;
            }

            return linkableTypes;
        }

        private async Task<string[]> GetLinkableTypesFromFieldDefinitionAsync(string part, string field)
        {
            var partDefinition = await _contentDefinitionManager.GetPartDefinitionAsync(part);
            var partFieldDefinition = partDefinition?.Fields
               .FirstOrDefault(f => f.Name == field);

            var fieldSettings = partFieldDefinition?.GetSettings<BlockFieldSettings>();

            if (fieldSettings == null)
            {
                throw new Exception("Unable to find field definition");
            }

            return fieldSettings.LinkableContentTypes;
        }

        #endregion
    }
}
