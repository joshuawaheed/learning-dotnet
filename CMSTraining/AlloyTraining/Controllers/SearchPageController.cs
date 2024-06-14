using AlloyTraining.Business.ExtensionMethods;
using AlloyTraining.Models.Pages;
using AlloyTraining.Models.ViewModels;
using EPiServer.Filters;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Controllers
{
    public class SearchPageController : PageControllerBase<SearchPage>
    {
        public SearchPageController(IContentLoader loader) : base(loader)
        {
        }
        
        public IActionResult Index(SearchPage currentPage, string q)
        {
            SearchPageViewModel viewmodel = new(currentPage);
            
            viewmodel.StartPage = loader.Get<StartPage>(ContentReference.StartPage);
            
            viewmodel.MenuPages = FilterForVisitor
                .Filter(loader.GetChildren<SitePageData>(ContentReference.StartPage))
                .Cast<SitePageData>()
                .Where(page => page.VisibleInMenu);
            
            viewmodel.Section = currentPage.ContentLink.GetSection();
            
            if (!string.IsNullOrWhiteSpace(q))
            {
                viewmodel.SearchText = q;
                
                ITypeSearch<SitePageData> query = SearchClient.Instance
                    .Search<SitePageData>()
                    .For(q)
                    .FilterForVisitor()
                    .FilterOnCurrentSite();
                
                IContentResult<SitePageData> results = query.GetContentResult();
                
                viewmodel.SearchResults = results
                    .Select(x => new Result
                    {
                        Title = x.MetaTitle ?? x.Name,
                        Description = x.MetaDescription?.TruncateAtWord(20),
                        Url = x.PageLink.ExternalURLFromReference()
                    })
                    .ToList();
            }
            return View(viewmodel);
        }
    }
}
