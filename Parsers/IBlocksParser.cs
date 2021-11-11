using Etch.OrchardCore.Blocks.Fields;
using Etch.OrchardCore.Blocks.Models;
using OrchardCore.ContentManagement;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Blocks.Parsers
{
    public interface IBlocksParser
    {
        Task<IList<dynamic>> RenderAsync(BlockField field);
        Task<IList<dynamic>> RenderAsync(BlockBodyPart part);
        Task<IList<dynamic>> RenderAsync(string data, ContentItem contentItem);
    }
}
