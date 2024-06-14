using EPiServer.Framework.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Media
{
    [ContentType(
        Description = "Use this to upload Portable Document Format (PDF) files.",
        DisplayName = "Portable Document Format",
        GUID = "1d8746ba-826b-4979-a7bc-56e8064f69df")]
    [MediaDescriptor(ExtensionString = "pdf")]
    public class PdfFile : MediaData
    {
        [Display(Name = "Render preview image")]
        // false: render as simple hyperlink
        // true: render as clickable thumbnail preview image
        public virtual bool RenderPrevewImage { get; set; }
    }
}
