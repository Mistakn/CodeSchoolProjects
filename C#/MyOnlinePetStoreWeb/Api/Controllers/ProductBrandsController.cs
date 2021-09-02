using Microsoft.AspNetCore.Mvc;
using MyOnlinePetStore.Shared;
using MyOnlinePetStoreWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Api.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class ProductBrandsController : ControllerBase {


        private readonly IDbShopService _shopService;


        public ProductBrandsController(IDbShopService shopService) {
            _shopService = shopService;
        }



        [HttpGet]
        public async Task<List<ProductBrandDTO>> Get() {
            return (await _shopService.GetProductBrandsAsync()).Select(pb => new ProductBrandDTO {
                Id = pb.Id,
                Name = pb.Name
            }).ToList();
        }

    }
}
