using System.Web;

namespace Mvc.Placeholders.Text
{
    public interface IText
    {
        IHtmlString GetParagraphs(int paragraphs = 5, string surroundTag = "p");
    }
}
