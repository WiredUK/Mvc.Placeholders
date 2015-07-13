using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mvc.Placeholders.Enums;

namespace Mvc.Placeholders.Tests
{
    [TestClass]
    public class ImageTests
    {
        [TestMethod]
        public void CanGetBasicImage()
        {
            var result = Images.PlaceholderImage(null, 200, 300, ImageSource.StevenSegal);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CanGetFpoImgImage()
        {
            var result = Images.FpoImgImage(null, 200, 300, "Don't care", "000000", "ffffff");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CanGetCageImage()
        {
            var result = Images.CageholderImage(null, 200, 300, NicolasCageType.Crazy);

            Assert.IsNotNull(result);
        }
    }
}
