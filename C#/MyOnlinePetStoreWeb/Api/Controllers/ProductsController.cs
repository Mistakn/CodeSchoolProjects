using Microsoft.AspNetCore.Mvc;
using MyOnlinePetStoreWeb.Entities;
using MyOnlinePetStoreWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Api.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller {

        private readonly IDbShopService _shopService;


        public ProductsController(IDbShopService shopService) {
            _shopService = shopService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get() {
            return await _shopService.GetProductsAsync();
        }


        [HttpGet("filter")]
        public async Task<ActionResult<List<Product>>> Get(string search, int? brand, bool filter) {
            return await _shopService.GetProductsByFilterAsync(search, brand, filter);
        }


        [HttpGet("byName")]
        public async Task<ActionResult<List<Product>>> Get(string name) {
            return await _shopService.GetProductsByNameAsync(name);
        }


        [HttpGet("byId")]
        public async Task<Product> Get(int id) {
            return await _shopService.GetProductAsync(id);
        }

    }
}
