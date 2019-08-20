using Etch.OrchardCore.EditorJS.Drivers;
using Etch.OrchardCore.EditorJS.Fields;
using Etch.OrchardCore.EditorJS.Parsers;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Modules;

namespace Etch.OrchardCore.EditorJS
{
    public class Startup : StartupBase
    {
        static Startup()
        {

        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ContentField, WYSIWYGField>();
            services.AddScoped<IContentFieldDisplayDriver, WYSIWYGFieldDriver>();

            services.AddScoped<IBlocksParser, BlocksParser>();
        }
    }
}
