using MyOnlinePetStoreClient.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MyOnlinePetStore.Shared;

namespace MyOnlinePetStoreClient.Services.Implementations {
    public class OrderAPI : IOrderAPI {

        private readonly HttpClient _httpClient;

        public OrderAPI(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task AddProductToOrderAsync(AddProductToOrderDTO addProductToOrderDTO) {
            await _httpClient.PostAsJsonAsync("api/orders/AddProductToOrder", addProductToOrderDTO);
        }
    }
}
