using MyOnlinePetStore.Shared;
using MyOnlinePetStoreClient.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyOnlinePetStoreClient.Services.Implementations {
    public class ProductBrandAPI : IProductBrandAPI {

        private readonly HttpClient _httpClient;


        public ProductBrandAPI(HttpClient httpClient) {
            _httpClient = httpClient;
        }


        public async Task<List<ProductBrandDTO>> GetProductBrandsAsync() {
            return await _httpClient.GetFromJsonAsync<List<ProductBrandDTO>>("api/productbrands");
        }

    }
}
