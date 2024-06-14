using AlloyTraining.Models.Blocks;
using AlloyTraining.Models.ViewModels;
using EPiServer.Filters;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Components
{
    public class ListingBlockComponent : BlockComponent<ListingBlock>
    {
        protected readonly IContentLoader _contentLoader;

        public ListingBlockComponent(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        protected override IViewComponentResult InvokeComponent(ListingBlock currentContent)
        {
            var viewmodel = new ListingBlockViewModel
            {
                Heading = currentContent.Heading
            };

            if (currentContent.ShowChildrenOfThisPage != null)
            {
                var children = _contentLoader.GetChildren<PageData>(currentContent.ShowChildrenOfThisPage);

                // Remove pages:
                // 1. that are not published
                // 2. that the visitor does not have Read access to
                // 3. that do not have a page template
                var filteredChildren = FilterForVisitor.Filter(children);

                // 4. that do not have "Display in navigation" selected
                viewmodel.Pages = filteredChildren.Cast<PageData>().Where(page => page.VisibleInMenu);
            }

            return View(viewmodel);
        }
    }
}
