using MyOnlinePetStore.Shared;
using MyOnlinePetStoreClient.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyOnlinePetStoreClient.Services.Implementations {
    public class ProductAPI : IProductAPI {


        private readonly HttpClient _httpClient;


        public ProductAPI(HttpClient httpClient) {
            _httpClient = httpClient;
        }


        public async Task<List<ProductDTO>> GetProductsAsync(string search, string brand, bool filter) {
            return await _httpClient.GetFromJsonAsync<List<ProductDTO>>($"api/products/filter?search={search}&brand={brand}&filter={filter}");
        }
    }
}
