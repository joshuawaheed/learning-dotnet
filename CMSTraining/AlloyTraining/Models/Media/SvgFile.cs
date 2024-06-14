using EPiServer.Framework.Blobs;
using EPiServer.Framework.DataAnnotations;

namespace AlloyTraining.Models.Media
{
    [ContentType(
        Description = "Use this to upload Scalable Vector Graphic (SVG) images.",
        DisplayName = "SVG File",
        GUID = "e12d5af6-a402-443f-a362-5629b778bbe4")]
    [MediaDescriptor(ExtensionString = "svg")]
    public class SvgFile : ImageData
    {
        // instead of generating a smaller bitmap file for thumbnail,
        // use the same binary vector image for thumbnail
        public override Blob Thumbnail { get => base.BinaryData; }
    }
}
