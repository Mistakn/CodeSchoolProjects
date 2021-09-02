using MyOnlinePetStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreClient.Services.Interfaces {
    public interface IProductAPI {

        Task<List<ProductDTO>> GetProductsAsync(string search, string brand, bool filter);

    }
}
