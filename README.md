---

> Note: This project is no longer maintained. It was only ever meant as a toy experiment, but I'm happy to leave the code here in case anyone finds any of it useful.

---

# Mvc.Placeholders
Generate placeholder images and text with MVC Html Helpers

So this is mostly for fun but can be useful (for client ready demos, I'd probably stay away from the fancy placholder images and bacon ipsum!)

## Documentation

Since people appear to be using it, here's some examples.

### Setting up

There are two ways to get images and text. You can use the HTML Helper methods or invoke the classes directly. The reason for the direct method would be that some of them have more specific options. For example, Nicolas Cage can look normal, gray or crazy.

#### HTML Helpers

To use these, you first need to be able to reference them. So you can either add a `using` statement to each view where they are needed or add the namespace to your web.config (the one in the `Views` folder, not in the root of your project!)

Per view:

    @using Mvc.Placeholders.Helpers

Globally:

    <system.web.webPages.razor>
      <pages ...>
        <namespaces>
		  ....
	      <add namespace="Mvc.Placeholders.Helpers"/>
	    </namespaces>
	  </pages>
    <system.web.webPages.razor>
    
##### Images

    @Html.PlaceholderImage(300, 200, ImageSource.BillMurray)
    @Html.FpoImgImage(300, 200, "Some text")

This will generate HTML similar to:

    <img src="http://fillmurray.com/300/200">
    <img src="http://fpoimg.com/300x200?text=Some+text&amp;bg_color=d1d1d1&amp;text_color=616161">


##### Text

    @Html.Ipsum(TextSource.BaconIpsum, 4, "div")

Which will generate 4 paragraphs of Bacon replated text.

## Example!

![Example image](http://i.imgur.com/HfPNpns.png)


## Nuget

This is also available as a [Nuget package](http://www.nuget.org/packages/Mvc.Placeholders/), you can install it using the GUI by searching for `Mvc.Placeholders` or from the package mabager console in Visual Studio:

    Install-Package Mvc.Placeholders
