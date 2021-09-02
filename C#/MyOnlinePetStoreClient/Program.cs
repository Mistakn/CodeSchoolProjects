using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyOnlinePetStoreClient.Services.Implementations;
using MyOnlinePetStoreClient.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyOnlinePetStoreClient {
    public class Program {
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("MyOnlinePetStoreWeb", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped(c => c.GetRequiredService<IHttpClientFactory>().CreateClient("MyOnlinePetStoreWeb"));

            builder.Services.AddApiAuthorization();
            builder.Services.AddScoped<IProductAPI, ProductAPI>();
            builder.Services.AddScoped<IProductBrandAPI, ProductBrandAPI>();
            builder.Services.AddScoped<IOrderAPI, OrderAPI>();

            await builder.Build().RunAsync();
        }
    }
}
