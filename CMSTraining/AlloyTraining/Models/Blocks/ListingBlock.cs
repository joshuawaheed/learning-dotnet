using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Blocks
{
    [ContentType(
        Description = "Choose a page in the tree, and its children will be listed, with a heading.",
        DisplayName = "Listing",
        GroupName = SiteGroupNames.Common,
        GUID = "f1718e25-16a5-4d75-a691-c8af5ca18b4e")]
    [SiteBlockIcon]
    public class ListingBlock : BlockData
    {
        [Display(Name = "Heading", Order = 10)]
        public virtual string Heading { get; set; }

        [Display(Name = "Show children of this page", Order = 20)]
        public virtual PageReference ShowChildrenOfThisPage { get; set; }
    }
}
