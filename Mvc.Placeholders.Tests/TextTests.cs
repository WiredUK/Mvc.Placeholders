using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mvc.Placeholders.Tests
{
    [TestClass]
    public class TextTests
    {
        [TestMethod]
        public void CanGetBasicText()
        {
            var text = Text.BasicIpsum(null, 6, "span");

            Assert.IsNotNull(text);
        }

        [TestMethod]
        public void CanGetBaconText()
        {
            var text = Text.BaconIpsum(null, 6, "div");

            Assert.IsNotNull(text);
        }
    }
}
