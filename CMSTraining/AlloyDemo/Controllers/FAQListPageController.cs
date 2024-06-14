using AlloyDemo.Models.Pages;
using AlloyDemo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AlloyDemo.Controllers
{
    public class FAQListPageController : PageControllerBase<FAQListPage>
    {
        protected readonly IContentRepository repo;

        public FAQListPageController(IContentRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult Index(FAQListPage currentPage)
        {
            PageViewModel<FAQListPage> viewmodel = PageViewModel.Create(currentPage);
            IEnumerable<FAQItemPage> faqs = repo.GetChildren<FAQItemPage>(currentPage.ContentLink);
            viewmodel.CurrentPage.FAQItems = faqs;
            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult CreateFAQItem(FAQListPage currentPage, string question)
        {
            FAQItemPage faqItem = repo.GetDefault<FAQItemPage>(currentPage.ContentLink);
            
            // if someone is logged in then CreatedBy and ChangedBy will be set,
            // otherwise they will be empty string which is shown as "installer"
            if (string.IsNullOrEmpty(faqItem.CreatedBy))
            {
                faqItem.CreatedBy = "Anonymous";
            }

            if (string.IsNullOrEmpty(faqItem.ChangedBy))
            {
                faqItem.ChangedBy = "Anonymous";
            }

            faqItem.Question = new XhtmlString(question);
            faqItem.Name = "Q. " + question;

            repo.Save(
                faqItem,
                EPiServer.DataAccess.SaveAction.CheckOut,
                EPiServer.Security.AccessLevel.Read
            );

            return RedirectToAction("Index");
        }
    }
}
