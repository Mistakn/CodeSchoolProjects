// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace MyOnlinePetStoreClient.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "d:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "d:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "d:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "d:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "d:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "d:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "d:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "d:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "d:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using MyOnlinePetStoreClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "d:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using MyOnlinePetStoreClient.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "d:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using MyOnlinePetStore.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "d:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using MyOnlinePetStoreClient.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "d:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using MyOnlinePetStoreClient.Services.Implementations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "d:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using MyOnlinePetStoreClient.Services.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "d:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using MyOnlinePetStoreClient.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "d:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using MyOnlinePetStoreClient.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "d:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "d:\Git Repos\CodeSchool\MyOnlinePetStoreClient\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 37 "d:\Git Repos\CodeSchool\MyOnlinePetStoreClient\Pages\Index.razor"
       

    private string brand { get; set; }
    private string search { get; set; }
    private bool filter { get; set; }

    private List<ProductDTO> products = new();

    protected override async Task OnInitializedAsync() {

        NavigationManager.LocationChanged += async (sender, e) => await LocationChanged(sender, e);

        brand = NavigationManager.QueryString("brand");
        search = NavigationManager.QueryString("search");

        await getProducts(search, brand, filter);
    }

    // Attaches this event to the Locationchanged event
    async Task LocationChanged(object sender, LocationChangedEventArgs e) {
        brand = ExtensionMethods.QueryString(e.Location, "brand");
        search = ExtensionMethods.QueryString(e.Location, "search");

        await getProducts(search, brand, filter);
    }


    async Task FilterChange(ChangeEventArgs e) {
        filter = e.Value.ToString() == "true" ? true : false;
        brand = NavigationManager.QueryString("brand");
        search = NavigationManager.QueryString("search");

        await getProducts(search, brand, filter);
    }

    async Task getProducts(string search, string brand, bool filter) {
        try {
            products = await ProductAPI.GetProductsAsync(search, brand, filter);
        } catch (AccessTokenNotAvailableException ex) {
            ex.Redirect();
        }
        StateHasChanged();
    }


    void IDisposable.Dispose() {
        NavigationManager.LocationChanged -= async (sender, e) => await LocationChanged(sender, e);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IProductAPI ProductAPI { get; set; }
    }
}
#pragma warning restore 1591
