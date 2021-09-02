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
    public class EditCustomerAddressModel : PageModel {

        [BindProperty]
        public AddressDTO AddressDTO { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CustomerID { get; set; }


        private readonly IDbCustomerService _customerService;


        public EditCustomerAddressModel(IDbCustomerService customerService) {
            _customerService = customerService;
        }


        public async Task OnGetAsync() {
            Customer customerToEdit = await _customerService.GetCustomerAsync(CustomerID);

            if (customerToEdit.Address != null) {
                AddressDTO = new AddressDTO {
                    StreetAddress = customerToEdit.Address.StreetAddress,
                    City = customerToEdit.Address.City,
                    StateOrProvinceAbbr = customerToEdit.Address.StateOrProvinceAbbr,
                    Country = customerToEdit.Address.Country,
                    PostalCode = customerToEdit.Address.PostalCode,
                };
            }
        }


        public async Task<IActionResult> OnPostAsync() {

            if (ModelState.IsValid) {
                Customer customerToEdit = await _customerService.GetCustomerAsync(CustomerID);

                Address address = new Address(AddressDTO.StreetAddress, AddressDTO.City, AddressDTO.StateOrProvinceAbbr, AddressDTO.Country, AddressDTO.PostalCode);

                customerToEdit.Address = address;

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
