namespace Mvc.Placeholders.Images.Generators
{
    public class NiceNiceJpg : ImageBase
    {
        private const string UrlFormatBasic = "http://nicenicejpg.com/{x}/{y}";

        public override string UrlFormat
        {
            get { return UrlFormatBasic; }
        }
    }
}
