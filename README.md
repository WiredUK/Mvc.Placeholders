# Mvc.Placeholders
Generate placeholder images and text with MVC Html Helpers

So this is mostly for fun but can be useful (for client ready demos, I'd probably stay away from the fancy placholder images and bacon ipsum!)

##Documentation

Since people appear to be using it, here's some examples.

###Images

    @Html.PlaceholderImage(300, 200, ImageSource.BillMurray)
    @Html.FpoImgImage(300, 200, "Some text")

This will generate HTML similar to:

    <img src="http://fillmurray.com/300/200">
    <img src="http://fpoimg.com/300x200?text=Some+text&amp;bg_color=d1d1d1&amp;text_color=616161">


###Text

    @Html.Ipsum(TextSource.BaconIpsum, 4, "div")

Which will generate 4 paragraphs of Bacon replated text.

##Example!

![Example image](http://i.imgur.com/HfPNpns.png)


##Nuget

This is also available as a [Nuget package](http://www.nuget.org/packages/Mvc.Placeholders/), you can install it using the GUI by searching for `Mvc.Placeholders` or from the package mabager console in Visual Studio:

    Install-Package Mvc.Placeholders
