namespace Mvc.Placeholders.Images.Generators
{
    public class BaconMockup : ImageBase
    {
        private const string UrlFormatBasic = "http://baconmockup.com/{x}/{y}";

        public override string UrlFormat
        {
            get { return UrlFormatBasic; }
        }
    }
}
