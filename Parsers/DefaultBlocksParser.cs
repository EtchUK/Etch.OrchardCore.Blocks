using Etch.OrchardCore.Blocks.Fields;
using Etch.OrchardCore.Blocks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Blocks.Parsers
{
    public class DefaultBlocksParser : IBlocksParser
    {
        public Task<IList<dynamic>> RenderAsync(BlockField field)
        {
            return Task.FromResult<IList<dynamic>>(new List<dynamic>());
        }

        public Task<IList<dynamic>> RenderAsync(BlockBodyPart part)
        {
            return Task.FromResult<IList<dynamic>>(new List<dynamic>());
        }
    }
}
