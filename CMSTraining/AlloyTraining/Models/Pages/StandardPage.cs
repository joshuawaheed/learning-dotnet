using AlloyTraining.Models.Blocks;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Pages
{
    [ContentType(
        Description = "Use this page type unless you need a more specialized one.",
        DisplayName = "Standard",
        GroupName = SiteGroupNames.Common,
        GUID = "1e73894b-4ec8-4d76-9d34-323cbc80433e")]
    [SitePageIcon]
    [AvailableContentTypes(Include = new[] { typeof(StandardPage) }, Exclude = new[] { typeof(ProductPage) })]
    public class StandardPage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Description =
            "The main body will be shown in the main content area of the page, using the " +
            "XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Name = "Main body",
            Order = 150)]
        public virtual XhtmlString MainBody { get; set; }

        public virtual EmployeeBlock Author { get; set; }
    }
}
