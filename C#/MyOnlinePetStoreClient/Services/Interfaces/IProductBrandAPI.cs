using MyOnlinePetStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreClient.Services.Interfaces {
    interface IProductBrandAPI {
        Task<List<ProductBrandDTO>> GetProductBrandsAsync();
    }
}
