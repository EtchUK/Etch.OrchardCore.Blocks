using Etch.OrchardCore.Blocks.Models;
using Etch.OrchardCore.Blocks.Utils;
using OrchardCore.Indexing;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Blocks.Indexing
{
    public class BlockBodyPartIndexHandler : ContentPartIndexHandler<BlockBodyPart>
    {
        public override Task BuildIndexAsync(BlockBodyPart part, BuildPartIndexContext context)
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