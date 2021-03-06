#pragma checksum "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\Components\ProductBrandsBar.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ae52fa660a7da1c42503759eb3abeff3688c7f0"
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
    public partial class ProductBrandsBar : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "container-fluid");
            __builder.AddAttribute(2, "b-z5310q7w2y");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "row border bg-secondary");
            __builder.AddAttribute(5, "b-z5310q7w2y");
            __builder.AddMarkupContent(6, "<div class=\"col-auto text-center rounded py-3 px-3\" b-z5310q7w2y><span class=\"h6 text-white\" b-z5310q7w2y>Filter by brand:</span></div>\r\n\r\n        ");
            __builder.AddMarkupContent(7, "<div class=\"col-auto\" b-z5310q7w2y><a href=\"/\" class=\"btn text-center rounded py-3 px-3 product_brand__item\" b-z5310q7w2y><span class=\"h5 text-white\" b-z5310q7w2y>All</span></a></div>");
#nullable restore
#line 15 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\Components\ProductBrandsBar.razor"
         foreach (var brand in brands) {

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<MyOnlinePetStoreClient.Components.ProductBrandItem>(8);
            __builder.AddAttribute(9, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MyOnlinePetStore.Shared.ProductBrandDTO>(
#nullable restore
#line 16 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\Components\ProductBrandsBar.razor"
                                    brand

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
#nullable restore
#line 17 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\Components\ProductBrandsBar.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 22 "D:\Git Repos\CodeSchool\MyOnlinePetStoreClient\Components\ProductBrandsBar.razor"
       
    private List<ProductBrandDTO> brands = new();

    protected override async Task OnInitializedAsync() {
        try {
            brands = await ProductBrandAPI.GetProductBrandsAsync();
        } catch (AccessTokenNotAvailableException ex) {
            ex.Redirect();
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IProductBrandAPI ProductBrandAPI { get; set; }
    }
}
#pragma warning restore 1591
