using System.Web;
using Mvc.Placeholders.Helpers;
using Mvc.Placeholders.Images.Enums;

namespace Mvc.Placeholders.Images.Generators
{
    public class PlaceCage : ImageBase
    {
        private const string UrlFormatBasic = "http://placecage.com/{x}/{y}";
        private const string UrlFormatGray = "http://placecage.com/g/{x}/{y}";
        private const string UrlFormatCrazy = "http://placecage.com/c/{x}/{y}";

        public override string UrlFormat
        {
            get { return UrlFormatBasic; }
        }

        public IHtmlString PlaceCageImage(int x, int y, PlaceCageType cageType)
        {
            var url = GetUrlFormatFromType(cageType);
            return GetImageTag(url.FormatWith(new { x, y }));
        }

        private static string GetUrlFormatFromType(PlaceCageType cageType)
        {
            switch (cageType)
            {
                case PlaceCageType.Gray:
                    return UrlFormatGray;
                case PlaceCageType.Crazy:
                    return UrlFormatCrazy;
                default:
                    return UrlFormatBasic;
            }
        }
    }
}
