using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Mvc.Placeholders.Enums;
using Mvc.Placeholders.Helpers;
using Newtonsoft.Json;

namespace Mvc.Placeholders
{
    public static class Text
    {
        #region URL Formats
        private static readonly string[] UrlFormats = 
        {
            UrlFormatBasicIpsum,
            UrlFormatBaconIpsum
        };

        private const string UrlFormatBasicIpsum = "http://loripsum.net/api/{paragraphs}/plaintext";
        private const string UrlFormatBaconIpsum = "https://baconipsum.com/api/?type=meat-and-filler&paras={paragraphs}";
        #endregion
        
        public static IHtmlString Ipsum(this HtmlHelper helper, 
            TextSource source = TextSource.BaconIpsum, int paragraphs = 5, string surroundTag = "p")
        {
            switch (source)
            {
                case TextSource.BaconIpsum:
                    return BaconIpsum(helper, paragraphs, surroundTag);

                default:
                    return BasicIpsum(helper, paragraphs, surroundTag);
            }

        }

        public static IHtmlString BasicIpsum(this HtmlHelper helper,
            int paragraphs = 5, string surroundTag = "p")
        {
            var url = GetUrlFormat(TextSource.BasicIpsum).FormatWith(new
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

        public static IHtmlString BaconIpsum(this HtmlHelper helper,
            int paragraphs = 5, string surroundTag = "p")
        {
            var url = GetUrlFormat(TextSource.BaconIpsum).FormatWith(new
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

        #region Private methods
        private static string GetUrlFormat(TextSource source)
        {
            return UrlFormats[(int)source];            
        }
        #endregion
    }
}
