namespace Mvc.Placeholders.Images.Generators
{
    public class PlaceholdIt : ImageBase
    {
        private const string UrlFormatBasic = "http://placehold.it/{x}x{y}";

        public override string UrlFormat
        {
            get { return UrlFormatBasic; }
        }
    }
}
