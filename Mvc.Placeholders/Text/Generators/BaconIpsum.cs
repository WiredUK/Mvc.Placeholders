using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Mvc.Placeholders.Helpers;
using Newtonsoft.Json;

namespace Mvc.Placeholders.Text.Generators
{
    public class BaconIpsum : IText
    {
        private const string UrlFormat = "https://baconipsum.com/api/?type=meat-and-filler&paras={paragraphs}";

        public IHtmlString GetParagraphs(int paragraphs = 5, string surroundTag = "p")
        {
            var url = UrlFormat.FormatWith(new
            {
                paragraphs
            });

            using (var client = new HttpClient())
            {
                var result = client.GetStringAsync(url).Result;
                var paragraphStrings = JsonConvert.DeserializeObject<List<string>>(result);

                return new HtmlString(string.Join(
                    "\n",
                    paragraphStrings
                        .Select(p => string.Format("<{0}>{1}</{0}>", surroundTag, p))));
            }               
        }
    }
}
