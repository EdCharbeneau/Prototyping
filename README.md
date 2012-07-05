#Prototyping for ASP.Net MVC
The Prototyping for MVC package provides a fluent API that creates Lorem Ipsum text and placeholder images at runtime using simple helper extension methods. The Prototyping package for MVC is specifically for reducing prototyping markup.

###Install Prototyping for MVC via NuGet:
http://nuget.org/packages/Prototyping_MVC
or
PM> Install-Package Prototyping_MVC

###Getting started.

```csharp
@using Prototyping.Ipsum;
@using Prototyping.Placeholdit;
//Ipsum examples //Random paragraph
@Html.Ipsum()
//Paragraph
@Html.Ipsum().p()
//Four paragraphs, ten sentences
@Html.Ipsum().p(4, 10)
//Paragraph with the attribute class="fancy"
@Html.Ipsum().p(htmlAttributes: new { @class = "fancy" })
//h1 tag
@Html.Ipsum().h1()
//h1 tag, just one word long
@Html.Ipsum().h1(1)
//h2 tag, with the attribute data-special="true"
@Html.Ipsum().h2(5, new { data_special = "true" })
//unordered list
@Html.Ipsum().ul()
//unordered list of links
@Html.Ipsum().ul(links: true)
//a mock blog post
@Html.Ipsum().BlogPost()
//non HTML ipsum
@Html.Ipsum().Words(50)
@Html.Ipsum().Paragraphs(2)
//Fluent api
@Html.Ipsum().h1().p().h2().p().h3().ol(10,3, true)
//Image placeholder
@Html.Placehold(300,300)
```

####Credits
Placeholder helper uses the http://placehold.it service and requires a network connection.

NLipsum generator http://code.google.com/p/nlipsum/ for the Lorem Ipsum engine

##### Learn more
You can see a demo as part of the tutorial in *Responsive design using Foundation with ASP.Net MVC*
http://www.simple-talk.com/dotnet/asp.net/responsive-design-using-foundation-with-asp.net-mvc/