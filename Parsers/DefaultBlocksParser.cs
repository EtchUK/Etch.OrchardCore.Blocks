using System.Collections.Generic;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Blocks.Parsers
{
    public class DefaultBlocksParser : IBlocksParser
    {
        public Task<IList<dynamic>> RenderAsync(string data)
        {
            return Task.FromResult<IList<dynamic>>(new List<dynamic>());
        }
    }
}
