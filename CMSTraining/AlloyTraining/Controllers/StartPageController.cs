using AlloyTraining.Models.Pages;
using EPiServer.Framework.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Controllers
{
    [TemplateDescriptor(Inherited = true)]
    public class StartPageController : PageControllerBase<StartPage>
    {
        public StartPageController(IContentLoader loader) : base(loader)
        {
        }

        public ActionResult Index(StartPage currentPage)
        {
            return View(CreatePageViewModel(currentPage));
        }
    }
}
