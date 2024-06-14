using AlloyDemo.Models.Pages;
using EPiServer.Labs.GridView;
using EPiServer.Labs.GridView.GridConfiguration;
using EPiServer.Shell;

namespace AlloyDemo.Business.GridViews
{
    [UIDescriptorRegistration]
    public class ContainerPageGridViewUIDescriptor : ExtendedUIDescriptor<ContainerPage>
    {
        public ContainerPageGridViewUIDescriptor() : base(ContentTypeCssClassNames.Container)
        {
            DefaultView = SearchContentViewContentData.ViewKey;

            GridSettings = new GridSettings
            {
                Columns = new ColumnsListBuilder()
                    .WithContentName()
                    .WithRawPropertyValue(columnName: "Phone", propertyName: "Phone")
                    .WithRawPropertyValue(columnName: "Email", propertyName: "Email")
                    .WithContentStatus()
                    .WithPublishDate()
                    .WithEdit()
                    .WithActionMenu()
                    .Build()
                
                // other standard columns if you want them
                //.WithContentTypeName()
                //.WithCreatedBy()
                //.WithVisibleInMenu()
                //.WithCurrentLanguageBranch()
                //.WithPreviewUrl()
            };
        }
    }
}
