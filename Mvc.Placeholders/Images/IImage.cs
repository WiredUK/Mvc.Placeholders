using System.Web;

namespace Mvc.Placeholders.Images
{
    public interface IImage
    {
        string UrlFormat { get; }

        IHtmlString PlaceholderImage(int x, int y);
    }
}
