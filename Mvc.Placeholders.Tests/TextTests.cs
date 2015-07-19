using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mvc.Placeholders.Helpers;
using Mvc.Placeholders.Text.Enums;

namespace Mvc.Placeholders.Tests
{
    [TestClass]
    public class TextTests
    {
        [TestMethod]
        public void CanGetBasicText()
        {
            var text = TextHelpers.Ipsum(null, TextSource.Normal, 6, "span");

            Assert.IsNotNull(text);
        }

        [TestMethod]
        public void CanGetBaconText()
        {
            var text = TextHelpers.Ipsum(null, TextSource.BaconIpsum, 6, "div");

            Assert.IsNotNull(text);
        }
    }
}
