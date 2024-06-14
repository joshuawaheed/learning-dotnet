using EPiServer.Cms.TinyMce.Core;
using Microsoft.Extensions.DependencyInjection;

namespace AlloyDemo {
    public static class TinyMceExtensions {
        public static IServiceCollection AddTinyMceCustomizations(this IServiceCollection services) {
            services.Configure<TinyMceConfiguration>(config =>
            {
                // Add the advanced list styles, table, and code plugins
                // and append buttons for inserting and editing tables
                // and showing source code to the toolbar
                config.Default()
                    .AddSetting("entity_encoding", "raw")
                    .AddPlugin("advlist")
                    .AddPlugin("table").AppendToolbar("table")
                    .AddPlugin("code").AppendToolbar("code");
            });

            return services;
        }
    }
}