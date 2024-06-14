using AlloyTraining.Business.EditorDescriptors;
using AlloyTraining.Business.SelectionFactories;
using EPiServer.Shell.ObjectEditing;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Pages
{
    [ContentType(
        Description = "Use this for software products that Alloy sells.",
        DisplayName = "Product",
        GroupName = SiteGroupNames.Specialized,
        GUID = "a7b92149-8a6c-4c5f-a52b-3d5915d97128",
        Order = 20)]
    [SiteCommerceIcon]
    public class ProductPage : StandardPage//, IDisableOnPageEditView
    {
        [SelectOne(SelectionFactoryType = typeof(ThemeSelectionFactory))]
        [Display(
            GroupName = SystemTabNames.Content,
            Name = "Color theme",
            Order = 310)]
        public virtual string Theme { get; set; }

        [CultureSpecific]
        [Display(
            GroupName = SystemTabNames.Content,
            Name = "Unique selling points",
            Order = 320)]
        [Required]
        public virtual IList<string> UniqueSellingPoints { get; set; }

        [Display(
            Description = "Drag and drop blocks and pages with partial templates.",
            GroupName = SystemTabNames.Content,
            Name = "Main content area",
            Order = 330)]
        public virtual ContentArea MainContentArea { get; set; }

        [Display(
            Description = "Drag and drop blocks and pages with partial templates.",
            GroupName = SystemTabNames.Content,
            Name = "Related content area",
            Order = 340)]
        public virtual ContentArea RelatedContentArea { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            Theme = "theme1";
        }
    }
}
