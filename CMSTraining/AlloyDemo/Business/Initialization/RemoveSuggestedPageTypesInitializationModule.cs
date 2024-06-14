using EPiServer.Cms.Shell.UI.Rest;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace AlloyDemo.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class RemoveSuggestedPageTypesInitializationModule : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            var descriptor = context.Services.FirstOrDefault(d => d.ServiceType == typeof(IContentTypeAdvisor));
            
            if (descriptor != null)
            {
                context.Services.Remove(descriptor);
            }
        }

        public void Initialize(InitializationEngine context) { }
        public void Uninitialize(InitializationEngine context) { }
    }
}