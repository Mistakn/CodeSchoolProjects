#pragma checksum "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87aca4f9f79eff5ecdb74631693aeb2caf79c0d2"
// <auto-generated/>
#pragma warning disable 1591
namespace MyOnlinePetStoreClient.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using MyOnlinePetStoreClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using MyOnlinePetStoreClient.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using MyOnlinePetStore.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using MyOnlinePetStoreClient.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using MyOnlinePetStoreClient.Services.Implementations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using MyOnlinePetStoreClient.Services.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using MyOnlinePetStoreClient.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using MyOnlinePetStoreClient.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<MyOnlinePetStoreClient.Shared.NavMenu>(0);
            __builder.CloseComponent();
            __builder.AddMarkupContent(1, "\r\n\r\n");
            __builder.OpenComponent<MyOnlinePetStoreClient.Components.ProductBrandsBar>(2);
            __builder.CloseComponent();
            __builder.AddMarkupContent(3, "\r\n\r\n");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "container");
            __builder.AddAttribute(6, "b-1v4oowxehp");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "row justify-content-center");
            __builder.AddAttribute(9, "b-1v4oowxehp");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "col-12 col-lg-10");
            __builder.AddAttribute(12, "b-1v4oowxehp");
            __builder.AddContent(13, 
#nullable restore
#line 11 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\Shared\MainLayout.razor"
             Body

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
