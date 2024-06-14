using AlloyDemo.Models; // [SiteImageUrl]
using AlloyDemo.Models.Pages; // StartPage, SitePageData
using EPiServer.DataAnnotations; // [ContentType], [AvailableContentTypes]

namespace AlloyDemo.Features.DeleteContent
{
    [ContentType(DisplayName = "Delete Content", 
        GUID = "0f01522d-fa66-4dff-92f3-e395f2ed4f36", 
        GroupName = Globals.GroupNames.Specialized,
        Description = "Use this to soft or hard delete content.")]
    [SiteImageUrl]
    [AvailableContentTypes(IncludeOn = new[] { typeof(StartPage) })]
    public class DeleteContentPage : SitePageData
    {
    }
}