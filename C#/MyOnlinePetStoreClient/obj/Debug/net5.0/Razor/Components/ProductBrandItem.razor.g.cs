#pragma checksum "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\Components\ProductBrandItem.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90e31b301dc2e9c96c756d3d81b2f6d0031963f6"
// <auto-generated/>
#pragma warning disable 1591
namespace MyOnlinePetStoreClient.Components
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
    public partial class ProductBrandItem : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "col-auto");
            __builder.AddAttribute(2, "b-pdq6v76bny");
            __builder.OpenElement(3, "a");
            __builder.AddAttribute(4, "href", "/?brand=" + (
#nullable restore
#line 2 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\Components\ProductBrandItem.razor"
                      Data.Id

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "class", "btn text-center rounded py-3 px-3 product_brand__item");
            __builder.AddAttribute(6, "b-pdq6v76bny");
            __builder.OpenElement(7, "span");
            __builder.AddAttribute(8, "class", "h5 text-white");
            __builder.AddAttribute(9, "b-pdq6v76bny");
            __builder.AddContent(10, 
#nullable restore
#line 3 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\Components\ProductBrandItem.razor"
                                     Data.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 7 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\Components\ProductBrandItem.razor"
       
    [Parameter]
    public ProductBrandDTO Data { get; set; }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591