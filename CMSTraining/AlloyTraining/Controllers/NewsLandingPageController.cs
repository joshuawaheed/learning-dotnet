using AlloyTraining.Models.Pages;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Controllers
{
    public class NewsLandingPageController : PageControllerBase<NewsLandingPage>
    {
        public NewsLandingPageController(IContentLoader loader) : base(loader)
        {
        }

        public IActionResult Index(NewsLandingPage currentPage)
        {
            return View(CreatePageViewModel(currentPage));
        }
    }
}
