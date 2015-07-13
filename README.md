# Mvc.Placeholders
Generate placeholder images and text with MVC Html Helpers

So this is mostly for fun but can be useful (for client ready demos, I'd probably stay away from the fancy placholder images and bacon ipsum!)

##Documentation

Since people appear to be using it, here's some examples.

###Images

    @Html.PlaceholderImage(300, 200, Source.BillMurray)
    @Html.FpoImgImage(300, 200, "Some text")

###Text

    @Html.Ipsum(TextSource.BaconIpsum, 4, "div")
