using AlloyTraining.Models.Blocks;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Pages
{
    [ContentType(
        Description = "Use this as a landing page for a list of news articles.",
        DisplayName = "News Landing",
        GroupName = SiteGroupNames.News,
        GUID = "812fc93e-60ba-4f40-873a-6ac47c49fbc1")]
    [SitePageIcon]
    public class NewsLandingPage : StandardPage
    {
        [Display(Name = "News listing", Order = 315)]
        public virtual ListingBlock NewsListing { get; set; }
    }
}
