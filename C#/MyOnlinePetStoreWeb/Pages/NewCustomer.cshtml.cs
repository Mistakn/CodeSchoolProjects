using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyOnlinePetStoreWeb.Entities;
using MyOnlinePetStoreWeb.Models;
using MyOnlinePetStoreWeb.Services.Interfaces;

namespace MyOnlinePetStoreWeb.Pages {
    public class NewCustomerModel : PageModel {

        [BindProperty]
        public CustomerDTO CustomerDTO { get; set; }


        private readonly IDbCustomerService _customerService;


        public NewCustomerModel(IDbCustomerService customerService) {
            _customerService = customerService;
        }


        public void OnGet() {
        }


        public async Task<IActionResult> OnPostAsync() {

            if (ModelState.IsValid) {
                Customer customerToAdd = new Customer(CustomerDTO.FirstName, CustomerDTO.LastName, CustomerDTO.Email);

                if (CustomerDTO.Phone != null) {
                    customerToAdd.UpdatePhone(CustomerDTO.Phone);
                }

                try {
                    await _customerService.AddCustomerAsync(customerToAdd);
                } catch (Exception ex) {
                    throw new InvalidOperationException(ex.Message);
                }
                return RedirectToPage("/Customers");
            } else {
                ModelState.AddModelError(string.Empty, "Invalid data");
                return Page();
            }
        }
    }
}
