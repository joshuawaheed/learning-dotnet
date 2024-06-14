using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Pages
{
    public abstract class SitePageData : PageData
    {
        [CultureSpecific]
        [Display(
            GroupName = SiteTabNames.SEO,
            Name = "Meta title",
            Order = 100)]
        [StringLength(60, MinimumLength = 5)]
        public virtual string MetaTitle { get; set; }

        [CultureSpecific]
        [Display(
            GroupName = SiteTabNames.SEO,
            Name = "Meta keywords",
            Order = 200)]
        public virtual string MetaKeywords { get; set; }

        [CultureSpecific]
        [Display(
            GroupName = SiteTabNames.SEO,
            Name = "Meta description",
            Order = 300)]
        [UIHint(UIHint.Textarea)]
        public virtual string MetaDescription { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Name = "Page image",
            Order = 100)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference PageImage { get; set; }
    }
}
