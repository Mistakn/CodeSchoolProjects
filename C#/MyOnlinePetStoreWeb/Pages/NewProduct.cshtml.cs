using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyOnlinePetStoreWeb.Entities;
using MyOnlinePetStoreWeb.Models;
using MyOnlinePetStoreWeb.Services.Interfaces;

namespace MyOnlinePetStoreWeb.Pages {

    [Authorize(Roles = "Administrator, Manager")]
    public class NewProductModel : PageModel {

        [BindProperty]
        public ProductDTO ProductDTO { get; set; }


        private readonly IDbShopService _shopService;
        private readonly IImageService _imageService;


        public NewProductModel(IDbShopService shopService, IImageService imageService) {
            _shopService = shopService;
            _imageService = imageService;
        }


        public void OnGet() {
        }


        public async Task<IActionResult> OnPostAsync() {

            if (ModelState.IsValid) {
                var productToAdd = new Product(ProductDTO.Name, ProductDTO.Description, ProductDTO.Price);

                if (ProductDTO.Image != null) {
                    string imageURL = await _imageService.SaveImageAsync(ProductDTO.Image);
                    productToAdd.UpdateImage(imageURL);
                }

                try {
                    await _shopService.AddProductAsync(productToAdd);
                } catch (Exception ex) {
                    throw new InvalidOperationException(ex.Message);
                }
                return RedirectToPage("/index");
            } else {
                ModelState.AddModelError(string.Empty, "Invalid data");
                return Page();
            }
        }
    }
}
