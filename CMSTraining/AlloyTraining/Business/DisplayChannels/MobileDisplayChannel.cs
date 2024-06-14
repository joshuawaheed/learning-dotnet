using EPiServer.Framework.Web;
using EPiServer.Web;
using Wangkanai.Detection.Models;
using Wangkanai.Detection.Services;

namespace AlloyTraining.Business.DisplayChannels
{
    public class MobileDisplayChannel : DisplayChannel
    {
        public override string ChannelName => RenderingTags.Mobile;

        public override bool IsActive(HttpContext context)
        {
            var detection = context.RequestServices.GetRequiredService<IDetectionService>();
            return detection.Device.Type == Device.Mobile;
        }
    }
}
