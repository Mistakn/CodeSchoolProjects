using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyOnlinePetStoreWeb.Data;
using MyOnlinePetStoreWeb.Entities;
using MyOnlinePetStoreWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Pages {
    public class IndexModel : PageModel {

        public List<Product> Products { get; set; }

        [BindProperty]
        public int ProductID { get; set; }

        private readonly IDbShopService _shopService;
        private readonly ILogger<IndexModel> _logger;


        public IndexModel(ILogger<IndexModel> logger, IDbShopService shopService) {
            _logger = logger;
            _shopService = shopService;
        }


        public async Task OnGetAsync() {
            Products = await _shopService.GetProductsAsync();
        }


        public async Task OnPostAsync() {
            if (User.IsInRole(RolesEnum.Administrator.ToString())) {
                await _shopService.DeleteProductAsync(ProductID);
                Products = await _shopService.GetProductsAsync();
            }
        }
    }
}
