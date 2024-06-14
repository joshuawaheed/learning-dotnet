using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Blocks
{
    [ContentType(
        Description = "Use this for a rich editorial text that will be reused in multiple places",
        DisplayName = "Editorial",
        GroupName = SiteGroupNames.Common,
        GUID = "1768549a-5dc6-4b2e-8b62-4ff481b6913f")]
    [SiteBlockIcon]
    public class EditorialBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, reused in multiple places.",
            GroupName = SystemTabNames.Content,
            Name = "Main body",
            Order = 10)]
        public virtual XhtmlString MainBody { get; set; }
    }
}
