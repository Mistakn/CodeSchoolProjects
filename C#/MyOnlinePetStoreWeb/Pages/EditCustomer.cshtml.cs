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
    public class EditCustomerModel : PageModel {

        [BindProperty]
        public CustomerDTO CustomerDTO { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CustomerID { get; set; }


        private readonly IDbCustomerService _customerService;


        public EditCustomerModel(IDbCustomerService customerService) {
            _customerService = customerService;
        }


        public async Task OnGetAsync() {
            Customer customerToEdit = await _customerService.GetCustomerAsync(CustomerID);

            CustomerDTO = new CustomerDTO {
                CustomerID = customerToEdit.CustomerID,
                FirstName = customerToEdit.FirstName,
                LastName = customerToEdit.LastName,
                Email = customerToEdit.Email,
                Phone = customerToEdit.Phone
            };
        }


        public async Task<IActionResult> OnPostAsync() {

            if (ModelState.IsValid) {
                Customer customerToEdit = await _customerService.GetCustomerAsync(CustomerDTO.CustomerID);

                customerToEdit.Update(CustomerDTO.FirstName, CustomerDTO.LastName, CustomerDTO.Email, CustomerDTO.Phone);

                try {
                    await _customerService.UpdateCustomerAsync(customerToEdit);
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
