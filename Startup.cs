using Etch.OrchardCore.Blocks.Drivers;
using Etch.OrchardCore.Blocks.Fields;
using Etch.OrchardCore.Blocks.Parsers;
using Etch.OrchardCore.Blocks.ViewModels.Blocks;
using Fluid;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Modules;

namespace Etch.OrchardCore.Blocks
{
    public class Startup : StartupBase
    {
        static Startup()
        {
            TemplateContext.GlobalMemberAccessStrategy.Register<EmbedBlockViewModel>();
            TemplateContext.GlobalMemberAccessStrategy.Register<HeadingBlockViewModel>();
            TemplateContext.GlobalMemberAccessStrategy.Register<ImageBlockViewModel>();
            TemplateContext.GlobalMemberAccessStrategy.Register<ListBlockViewModel>();
            TemplateContext.GlobalMemberAccessStrategy.Register<ParagraphBlockViewModel>();
            TemplateContext.GlobalMemberAccessStrategy.Register<QuoteBlockViewModel>();
            TemplateContext.GlobalMemberAccessStrategy.Register<RawBlockViewModel>();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ContentField, BlockField>();
            services.AddScoped<IContentFieldDisplayDriver, BlockFieldDriver>();

            services.AddScoped<IBlocksParser, DefaultBlocksParser>();
        }
    }
}
