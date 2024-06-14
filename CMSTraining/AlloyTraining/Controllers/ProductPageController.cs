using AlloyTraining.Models.Pages;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Controllers
{
    public class ProductPageController : PageControllerBase<ProductPage>
    {
        public ProductPageController(IContentLoader loader) : base(loader)
        {
        }

        public IActionResult Index(ProductPage currentPage)
        {
            return View(CreatePageViewModel(currentPage));
        }
    }
}
