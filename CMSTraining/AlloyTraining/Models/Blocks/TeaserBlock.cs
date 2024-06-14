using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Blocks
{
    [ContentType(
        Description = "Use this for rich text with heading, image and page link that will be reused in multiple places.",
        DisplayName = "Teaser",
        GroupName = SiteGroupNames.Common,
        GUID = "c14c5f97-3af9-443f-869e-7c7adee98641")]
    [SiteBlockIcon]
    public class TeaserBlock : BlockData
    {
        [CultureSpecific]
        [Display(
            GroupName = SystemTabNames.PageHeader,
            Name = "Heading",
            Order = 10)]
        public virtual string TeaserHeading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Rich text",
            Order = 20)]
        public virtual XhtmlString TeaserText { get; set; }

        [Display(
            GroupName = SystemTabNames.PageHeader,
            Name = "Image",
            Order = 30)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference TeaserImage { get; set; }

        [Display(
            GroupName = SystemTabNames.PageHeader,
            Name = "Link",
            Order = 40)]
        public virtual PageReference TeaserLink { get; set; }
    }
}
