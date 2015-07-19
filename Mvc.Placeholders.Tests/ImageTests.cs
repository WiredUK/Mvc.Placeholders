using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mvc.Placeholders.Images.Enums;
using Mvc.Placeholders.Helpers;

namespace Mvc.Placeholders.Tests
{
    [TestClass]
    public class ImageTests
    {
        [TestMethod]
        public void CanGetBasicImage()
        {
            var result = ImageHelpers.PlaceholderImage(null, 200, 300, ImageSource.StevenSeGallery);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CanGetFpoImgImage()
        {
            var result = ImageHelpers.FpoImgImage(null, 200, 300, "Don't care", "000000", "ffffff");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CanGetCageImage()
        {
            var result = ImageHelpers.PlaceCageImage(null, 200, 300, PlaceCageType.Crazy);

            Assert.IsNotNull(result);
        }
    }
}
