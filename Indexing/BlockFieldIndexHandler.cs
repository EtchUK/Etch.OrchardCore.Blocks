using Etch.OrchardCore.Blocks.Fields;
using Etch.OrchardCore.Blocks.Utils;
using OrchardCore.Indexing;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Blocks.Indexing
{
    public class BlockFieldPartIndexHandler : ContentFieldIndexHandler<BlockField>
    {
        public override Task BuildIndexAsync(BlockField part, BuildFieldIndexContext context)
        {
            var options = context.Settings.ToOptions()
                | DocumentIndexOptions.Sanitize
                | DocumentIndexOptions.Analyze
                ;

            foreach (var key in context.Keys)
            {
                context.DocumentIndex.Set(key, IndexUtils.RemoveBlocks(part.Data), options);
            }

            return Task.CompletedTask;
        }
    }
}