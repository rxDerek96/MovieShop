#pragma checksum "C:\Users\24275\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Reviews.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "465d61ab26b57ea55fc3d27784d831526915f1a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Reviews), @"mvc.1.0.view", @"/Views/Movies/Reviews.cshtml")]
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
#nullable restore
#line 1 "C:\Users\24275\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Reviews.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"465d61ab26b57ea55fc3d27784d831526915f1a8", @"/Views/Movies/Reviews.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53ed27a90769d57c4cf1e99ddf07e56b08d479e3", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Reviews : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ApplicationCore.Models.Response.MovieReviewResponseModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "C:\Users\24275\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Reviews.cshtml"
 foreach (var review in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div>
                    <hr />
                    <dl class=""row"">
                        <dt class=""col-sm-2"">
                            UserId:
                        </dt>
                        <dd class=""col-sm-12"">
                            ");
#nullable restore
#line 14 "C:\Users\24275\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Reviews.cshtml"
                       Write(review.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            Rating:\r\n                        </dt>\r\n                        <dd class=\"col-sm-12\">\r\n                            ");
#nullable restore
#line 20 "C:\Users\24275\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Reviews.cshtml"
                       Write(review.Rating);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            Review:\r\n                        </dt>\r\n                        <dd class=\"col-sm-12\">\r\n                            ");
#nullable restore
#line 26 "C:\Users\24275\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Reviews.cshtml"
                       Write(review.ReviewText);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </dd>\r\n                    </dl>\r\n                        \r\n                </div>\r\n");
#nullable restore
#line 31 "C:\Users\24275\source\repos\MovieShop\MovieShop.MVC\Views\Movies\Reviews.cshtml"
            }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ApplicationCore.Models.Response.MovieReviewResponseModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
