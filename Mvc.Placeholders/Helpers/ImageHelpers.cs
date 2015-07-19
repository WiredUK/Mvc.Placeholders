using System.Web;
using System.Web.Mvc;
using Mvc.Placeholders.Images;
using Mvc.Placeholders.Images.Enums;
using Mvc.Placeholders.Images.Generators;

namespace Mvc.Placeholders.Helpers
{
    public static class ImageHelpers
    {
        public static IHtmlString PlaceholderImage(this HtmlHelper helper, int x, int y, ImageSource imageSource = ImageSource.Normal)
        {
            var imageGenerator = GetGeneratorByType(imageSource);
            return imageGenerator.PlaceholderImage(x, y);
        }

        public static IHtmlString FpoImgImage(this HtmlHelper helper, int x, int y, string text = "", string bgColour = "d1d1d1", string textColour = "616161")
        {
            var fpoImg = new FpoImg();
            return fpoImg.FpoImgImage(x, y, text, bgColour, textColour);
        }

        public static IHtmlString PlaceCageImage(this HtmlHelper helper, int x, int y, PlaceCageType cageType)
        {
            var placeCage = new PlaceCage();
            return placeCage.PlaceCageImage(x, y, cageType);
        }

        private static ImageBase GetGeneratorByType(ImageSource imageSource)
        {
            switch (imageSource)
            {
                case ImageSource.FpoImg:
                    return new FpoImg();

                case ImageSource.PlaceCage:
                    return new PlaceCage();

                case ImageSource.FillMurray:
                    return new FillMurray();

                case ImageSource.NiceNiceJpg:
                    return new NiceNiceJpg();

                case ImageSource.StevenSeGallery:
                    return new StevenSeGallery();

                case ImageSource.BaconMockup:
                    return new BaconMockup();

                //case ImageSource.Normal:
                //case ImageSource.PlaceholdIt:
                default:
                    return new PlaceholdIt();
            }            
        }
    }
}
