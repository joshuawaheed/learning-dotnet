using AlloyTraining.Models.Blocks;
using AlloyTraining.Models.ViewModels;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Components
{
    [TemplateDescriptor(Tags = new[] { SiteTags.Full }, AvailableWithoutTag = true)]
    public class TeaserBlockComponent : BlockComponent<TeaserBlock>
    {
        protected override IViewComponentResult InvokeComponent(TeaserBlock currentContent)
        {
            var viewmodel = new TeaserBlockViewModel
            {
                CurrentBlock = currentContent,
                TodaysVisitorCount = new Random().Next(300, 900)
            };

            return View(viewmodel);
        }
    }

    [TemplateDescriptor(Tags = new[] { SiteTags.Wide }, AvailableWithoutTag = true)]
    public class TeaserBlockWideComponent : BlockComponent<TeaserBlock>
    {
        protected override IViewComponentResult InvokeComponent(TeaserBlock currentContent)
        {
            var viewmodel = new TeaserBlockViewModel
            {
                CurrentBlock = currentContent,
                TodaysVisitorCount = new Random().Next(300, 900)
            };

            return View(viewName: "wide", model: viewmodel);
        }
    }

    [TemplateDescriptor(Tags = new[] { SiteTags.Narrow }, AvailableWithoutTag = true)]
    public class TeaserBlockNarrowComponent : BlockComponent<TeaserBlock>
    {
        protected override IViewComponentResult InvokeComponent(TeaserBlock currentContent)
        {
            var viewmodel = new TeaserBlockViewModel
            {
                CurrentBlock = currentContent,
                TodaysVisitorCount = new Random().Next(300, 900)
            };

            return View(viewName: "narrow", model: viewmodel);
        }
    }
}
