#pragma checksum "D:\Git Repos\CodeSchool\MyOnlinePetStoreWeb\Views\Shared\_MostRecentOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b5fa1663e85dd360d4e47bf869158f87fcc6410d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MyOnlinePetStoreWeb.Pages.Shared.Views_Shared__MostRecentOrder), @"mvc.1.0.view", @"/Views/Shared/_MostRecentOrder.cshtml")]
namespace MyOnlinePetStoreWeb.Pages.Shared
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
#line 1 "D:\Git Repos\CodeSchool\MyOnlinePetStoreWeb\Views\_ViewImports.cshtml"
using MyOnlinePetStoreWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Git Repos\CodeSchool\MyOnlinePetStoreWeb\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Git Repos\CodeSchool\MyOnlinePetStoreWeb\Views\_ViewImports.cshtml"
using MyOnlinePetStoreWeb.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Git Repos\CodeSchool\MyOnlinePetStoreWeb\Views\_ViewImports.cshtml"
using MyOnlinePetStoreWeb.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Git Repos\CodeSchool\MyOnlinePetStoreWeb\Views\_ViewImports.cshtml"
using MyOnlinePetStoreWeb.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5fa1663e85dd360d4e47bf869158f87fcc6410d", @"/Views/Shared/_MostRecentOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0e61cea2fd986ee8ebcd9cf888f3713dc6f6789", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__MostRecentOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MyOnlinePetStoreWeb.Entities.Order>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Git Repos\CodeSchool\MyOnlinePetStoreWeb\Views\Shared\_MostRecentOrder.cshtml"
 if (Model != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""row border rounded p-3"">
        <div class=""col-12"">

            <div class=""row"">
                <span class=""h3 font-weight-bold"">Most recent order</span>
            </div>

            <div class=""row"">
                <span>Order ID: ");
#nullable restore
#line 12 "D:\Git Repos\CodeSchool\MyOnlinePetStoreWeb\Views\Shared\_MostRecentOrder.cshtml"
                           Write(Model.OrderID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n\r\n            <div class=\"row\">\r\n                <span>Status: ");
#nullable restore
#line 16 "D:\Git Repos\CodeSchool\MyOnlinePetStoreWeb\Views\Shared\_MostRecentOrder.cshtml"
                         Write(Model.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n\r\n            <div class=\"row\">\r\n                <span>Date placed: ");
#nullable restore
#line 20 "D:\Git Repos\CodeSchool\MyOnlinePetStoreWeb\Views\Shared\_MostRecentOrder.cshtml"
                              Write(Model.OrderPlaced);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n\r\n");
#nullable restore
#line 23 "D:\Git Repos\CodeSchool\MyOnlinePetStoreWeb\Views\Shared\_MostRecentOrder.cshtml"
             if (Model.ProductOrders != null && Model.ProductOrders.Any()) {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"row mt-3\">\r\n                    <span class=\"h4\">Products in order:</span>\r\n                </div>\r\n");
#nullable restore
#line 29 "D:\Git Repos\CodeSchool\MyOnlinePetStoreWeb\Views\Shared\_MostRecentOrder.cshtml"
                 foreach (var product in Model.ProductOrders) {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"row mt-1 pr-5\">\r\n                        <span>");
#nullable restore
#line 31 "D:\Git Repos\CodeSchool\MyOnlinePetStoreWeb\Views\Shared\_MostRecentOrder.cshtml"
                         Write(product);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n");
#nullable restore
#line 33 "D:\Git Repos\CodeSchool\MyOnlinePetStoreWeb\Views\Shared\_MostRecentOrder.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "D:\Git Repos\CodeSchool\MyOnlinePetStoreWeb\Views\Shared\_MostRecentOrder.cshtml"
                 

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 39 "D:\Git Repos\CodeSchool\MyOnlinePetStoreWeb\Views\Shared\_MostRecentOrder.cshtml"
} else {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row border rounded p-3\">\r\n        <div class=\"col-12\">\r\n            <span>No recent Order</span>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 45 "D:\Git Repos\CodeSchool\MyOnlinePetStoreWeb\Views\Shared\_MostRecentOrder.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyOnlinePetStoreWeb.Entities.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591
