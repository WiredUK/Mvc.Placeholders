using System.Web;
using Mvc.Placeholders.Helpers;

namespace Mvc.Placeholders.Images.Generators
{
    public class FpoImg : ImageBase
    {
        private const string UrlFormatBasic = "http://fpoimg.com/{x}x{y}";
        private const string UrlFormatFull = "http://fpoimg.com/{x}x{y}?text={text}&bg_color={bgColour}&text_color={textColour}";

        public override string UrlFormat
        {
            get { return UrlFormatBasic; }
        }

        public IHtmlString FpoImgImage(int x, int y, string text = "", string bgColour = "d1d1d1", string textColour = "616161")
        {
            return GetImageTag(UrlFormatFull.FormatWith(new
            {
                x,
                y,
                text = HttpUtility.UrlEncode(text),
                bgColour,
                textColour
            }));
        }
    }
}
