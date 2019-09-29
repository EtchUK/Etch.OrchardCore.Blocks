using Etch.OrchardCore.Blocks.Fields;
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
    }
}
