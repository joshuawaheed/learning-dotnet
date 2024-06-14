using AlloyTraining.Models.Pages;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Controllers
{
    [TemplateDescriptor(Inherited = true, Tags = new[] { RenderingTags.Mobile }, AvailableWithoutTag = false)]
    public class StartPageMobileController : PageControllerBase<StartPage>
    {
        public StartPageMobileController(IContentLoader loader) : base(loader)
        {
        }

        public ActionResult Index(StartPage currentPage)
        {
            return View(CreatePageViewModel(currentPage));
        }
    }
}
