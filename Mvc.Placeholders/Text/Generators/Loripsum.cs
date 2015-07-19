using System;
using System.Linq;
using System.Net.Http;
using System.Web;
using Mvc.Placeholders.Helpers;

namespace Mvc.Placeholders.Text.Generators
{
    public class Loripsum : IText
    {
        private const string UrlFormat = "http://loripsum.net/api/{paragraphs}/plaintext";

        public IHtmlString GetParagraphs(int paragraphs = 5, string surroundTag = "p")
        {
            var url = UrlFormat.FormatWith(new
            {
                paragraphs
            });

            using (var client = new HttpClient())
            {
                var result = client.GetStringAsync(url).Result;
                var lines = result.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                return new HtmlString(string.Join(
                    "\n",
                    lines
                        .Select(p => string.Format("<{0}>{1}</{0}>", surroundTag, p))));
            }                 
        }
    }
}
