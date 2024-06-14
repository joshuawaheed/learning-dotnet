using AlloyTraining.Models.Pages;
using AlloyTraining.Models.ViewModels;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Controllers
{
    [TemplateDescriptor(
        AvailableWithoutTag = false,
        Inherited = true,
        Tags = new[] { RenderingTags.Preview, RenderingTags.Edit },
        TemplateTypeCategory = TemplateTypeCategories.MvcController)]
    public class PreviewPageController : ActionControllerBase, IRenderTemplate<BlockData>
    {
        protected readonly IContentLoader _contentLoader;

        public PreviewPageController(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public IActionResult Index(IContent currentContent)
        {
            var startPage = _contentLoader.Get<SitePageData>(ContentReference.StartPage);
            var viewmodel = new PreviewPageViewModel(startPage, currentContent);
            return View(viewmodel);
        }
    }
}
