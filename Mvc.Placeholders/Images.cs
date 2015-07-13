using System.Web;
using System.Web.Mvc;
using Mvc.Placeholders.Enums;
using Mvc.Placeholders.Helpers;

namespace Mvc.Placeholders
{
    public static class Images
    {
        #region URL Formats
        private static readonly string[] UrlFormats = 
        {
            UrlFormatPlaceholdIt,
            UrlFormatFpoImg,
            UrlFormatNicolasCage,
            UrlFormatFillMurray,
            UrlFormatNiceNiceJpg,
            UrlFormatStevenSeGallery,
            UrlFormatBaconMockup
        };

        private const string UrlFormatPlaceholdIt = "http://placehold.it/{x}x{y}";
        private const string UrlFormatFpoImg = "http://fpoimg.com/{x}x{y}";
        private const string UrlFormatFpoImgFull = "http://fpoimg.com/{x}x{y}?text={text}&bg_color={bgColour}&text_color={textColour}";
        private const string UrlFormatNicolasCage = "http://placecage.com/{x}/{y}";
        private const string UrlFormatNicolasCageGray = "http://placecage.com/g/{x}/{y}";
        private const string UrlFormatNicolasCageCrazy = "http://placecage.com/c/{x}/{y}";
        private const string UrlFormatFillMurray = "http://fillmurray.com/{x}/{Y}";
        private const string UrlFormatNiceNiceJpg = "http://nicenicejpg.com/{x}/{y}";
        private const string UrlFormatStevenSeGallery = "http://www.stevensegallery.com/{x}/{y}";
        private const string UrlFormatBaconMockup = "http://baconmockup.com/{x}/{y}";

        #endregion

        public static IHtmlString PlaceholderImage(this HtmlHelper helper, int x, int y, ImageSource imageSource = ImageSource.Normal)
        {
            var url = GetUrlFormat(imageSource).FormatWith(new { x, y });

            return GetImageTag(url);
        }

        public static IHtmlString FpoImgImage(this HtmlHelper helper, int x, int y, string text = "", string bgColour = "d1d1d1", string textColour = "616161")
        {
            return GetImageTag(UrlFormatFpoImgFull.FormatWith(new
            {
                x,
                y,
                text = HttpUtility.UrlEncode(text),
                bgColour,
                textColour
            }));
        }

        public static IHtmlString CageholderImage(this HtmlHelper helper, int x, int y, NicolasCageType cageType)
        {
            string url;

            switch (cageType)
            {
                case NicolasCageType.Gray:
                    url = UrlFormatNicolasCageGray;
                    break;

                case NicolasCageType.Crazy:
                    url = UrlFormatNicolasCageCrazy;
                    break;

                default:
                    url = UrlFormatNicolasCage;
                    break;
            }

            return GetImageTag(url.FormatWith(new { x, y }));
        }

        #region Private methods
        private static IHtmlString GetImageTag(string imageUrl)
        {
            var img = new TagBuilder("img");
            img.Attributes.Add("src", imageUrl);
            return MvcHtmlString.Create(img.ToString());
        }

        private static string GetUrlFormat(ImageSource imageSource)
        {
            return UrlFormats[(int)imageSource];
        }
        #endregion

    }
}
