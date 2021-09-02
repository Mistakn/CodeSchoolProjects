using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyOnlinePetStoreWeb.Entities;
using MyOnlinePetStoreWeb.Models;
using MyOnlinePetStoreWeb.Services.Interfaces;

namespace MyOnlinePetStoreWeb.Pages {

    [Authorize(Roles = "Administrator, Manager")]
    public class EditProductModel : PageModel {


        [BindProperty]
        public ProductDTO ProductDTO { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ProductID { get; set; }


        private readonly IDbShopService _shopService;
        private readonly IImageService _imageService;


        public EditProductModel(IDbShopService productService, IImageService imageService) {
            _shopService = productService;
            _imageService = imageService;
        }


        public async Task OnGetAsync() {
            Product productToEdit = await _shopService.GetProductAsync(ProductID);

            ProductDTO = new ProductDTO {
                ProductID = productToEdit.ProductID,
                Name = productToEdit.Name,
                Description = productToEdit.Description,
                Price = productToEdit.Price,
                ImageURL = productToEdit.ImageURL
            };
        }


        public async Task<IActionResult> OnPostAsync() {
            if (ModelState.IsValid) {

                Product productToEdit = await _shopService.GetProductAsync(ProductID);

                productToEdit.Update(ProductDTO.Name, ProductDTO.Description, ProductDTO.Price);

                if (ProductDTO.Image != null) {
                    string imageURL = await _imageService.SaveImageAsync(ProductDTO.Image);
                    productToEdit.UpdateImage(imageURL);
                }

                await _shopService.UpdateProductAsync(productToEdit);
                return RedirectToPage("/index");

            } else {
                ModelState.AddModelError(string.Empty, "Invalid data");
                return Page();
            }
        }
    }
}
