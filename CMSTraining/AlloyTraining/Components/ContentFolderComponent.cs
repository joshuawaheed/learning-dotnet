using AlloyTraining.Models.ViewModels;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Components
{
    public class ContentFolderComponent : PartialContentComponent<ContentFolder>
    {
        protected readonly IContentLoader loader;

        public ContentFolderComponent(IContentLoader loader)
        {
            this.loader = loader;
        }

        protected override IViewComponentResult InvokeComponent(ContentFolder currentContent)
        {
            var viewModel = new ContentFolderViewModel
            {
                CurrentFolder = currentContent,
                ItemsCount = loader.GetChildren<IContent>(currentContent.ContentLink).Count()
            };

            return View(viewModel);
        }
    }
}
