using Etch.OrchardCore.Blocks.Fields;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Blocks.Parsers
{
    public interface IBlocksParser
    {
        Task<IList<dynamic>> RenderAsync(BlockField field);
    }
}
