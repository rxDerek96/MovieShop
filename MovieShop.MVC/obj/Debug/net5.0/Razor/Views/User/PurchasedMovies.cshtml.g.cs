#pragma checksum "C:\Users\24275\source\repos\MovieShop\MovieShop.MVC\Views\User\PurchasedMovies.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39db8ad9c613b4a402260fbeab61b1e56edfb936"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_PurchasedMovies), @"mvc.1.0.view", @"/Views/User/PurchasedMovies.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\24275\source\repos\MovieShop\MovieShop.MVC\Views\_ViewImports.cshtml"
using MovieShop.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\24275\source\repos\MovieShop\MovieShop.MVC\Views\_ViewImports.cshtml"
using MovieShop.MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39db8ad9c613b4a402260fbeab61b1e56edfb936", @"/Views/User/PurchasedMovies.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53ed27a90769d57c4cf1e99ddf07e56b08d479e3", @"/Views/_ViewImports.cshtml")]
    public class Views_User_PurchasedMovies : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ApplicationCore.Models.Response.MovieCardResponseModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\24275\source\repos\MovieShop\MovieShop.MVC\Views\User\PurchasedMovies.cshtml"
  
    ViewData["Title"] = "Purchased Movies";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Purchased Movies</h2>\r\n<div class=\"rounded\">\r\n    <div class=\"container-fluid bg-light\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 12 "C:\Users\24275\source\repos\MovieShop\MovieShop.MVC\Views\User\PurchasedMovies.cshtml"
             foreach (var movie in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-6 col-lg-3 col-sm-4 col-xl-2\">\r\n\r\n                    ");
#nullable restore
#line 16 "C:\Users\24275\source\repos\MovieShop\MovieShop.MVC\Views\User\PurchasedMovies.cshtml"
               Write(await Html.PartialAsync("_MovieCard", movie));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </div>\r\n");
#nullable restore
#line 19 "C:\Users\24275\source\repos\MovieShop\MovieShop.MVC\Views\User\PurchasedMovies.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ApplicationCore.Models.Response.MovieCardResponseModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
