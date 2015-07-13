using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mvc.Placeholders.Tests
{
    [TestClass]
    public class TextTests
    {
        [TestMethod]
        public async Task CanGetBasicText()
        {
            var text = await Text.BasicIpsum(null, 6, "span");

            Assert.IsNotNull(text);
        }

        [TestMethod]
        public async Task CanGetBaconText()
        {
            var text = await Text.BaconIpsum(null, 6, "div");

            Assert.IsNotNull(text);
        }
    }
}
