namespace Mvc.Placeholders.Images.Generators
{
    public class StevenSeGallery : ImageBase
    {
        private const string UrlFormatBasic = "http://www.stevensegallery.com/{x}/{y}";

        public override string UrlFormat
        {
            get { return UrlFormatBasic; }
        }
    }
}
