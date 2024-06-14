using AlloyDemo.Models.Pages;
using EPiServer.Labs.GridView;
using EPiServer.ServiceLocation;
using EPiServer.Shell;

namespace AlloyDemo.Business.GridViews
{
    [ServiceConfiguration(typeof(ViewConfiguration))]
    public class ContainerPageGridView : SearchContentView<ContainerPage>
    {
    }
}
