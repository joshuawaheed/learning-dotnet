using AlloyTraining.Models.Pages;
using EPiServer.Core;
using System.Collections.Generic;

namespace AlloyTraining.Models.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : SitePageData
    {
        public T CurrentPage { get; set; }
        public StartPage StartPage { get; set; }
        public IEnumerable<IContent> MenuPages { get; set; }
        public IContent Section { get; set; }

        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
        }
    }

    public static class PageViewModel
    {
        public static PageViewModel<T> Create<T>(T currentPage) where T : SitePageData
        {
            return new PageViewModel<T>(currentPage);
        }
    }
}
