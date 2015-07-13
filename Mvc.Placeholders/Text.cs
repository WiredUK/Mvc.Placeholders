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
        
        public static async Task<IHtmlString> Ipsum(this HtmlHelper helper, 
            TextSource source = TextSource.BaconIpsum, int paragraphs = 5, string surroundTag = "p")
        {
            switch (source)
            {
                case TextSource.BaconIpsum:
                    return await BaconIpsum(helper, paragraphs, surroundTag);

                default:
                    return await BasicIpsum(helper, paragraphs, surroundTag);
            }

        }

        public static async Task<IHtmlString> BasicIpsum(this HtmlHelper helper,
            int paragraphs = 5, string surroundTag = "p")
        {
            var url = GetUrlFormat(TextSource.BasicIpsum).FormatWith(new
            {
                paragraphs
            });
            
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(url);
                var lines = result.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                
                return new HtmlString(string.Join(
                    "\n",
                    lines
                        .Select(p => string.Format("<{0}>{1}</{0}>", surroundTag, p))));
            }     
      
        }

        public static async Task<IHtmlString> BaconIpsum(this HtmlHelper helper,
            int paragraphs = 5, string surroundTag = "p")
        {
            var url = GetUrlFormat(TextSource.BaconIpsum).FormatWith(new
            {
                paragraphs
            });

            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(url);
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
