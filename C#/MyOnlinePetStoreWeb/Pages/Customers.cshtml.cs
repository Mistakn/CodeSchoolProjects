using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyOnlinePetStoreWeb.Entities;
using MyOnlinePetStoreWeb.Services.Interfaces;

namespace MyOnlinePetStoreWeb.Pages {

    [Authorize(Roles = "Administrator, Manager")]
    public class CustomersModel : PageModel {

        public List<Customer> Customers { get; set; }

        [BindProperty]
        public int CustomerID { get; set; }

        private readonly IDbCustomerService _customerService;


        public CustomersModel(IDbCustomerService customerService) {
            _customerService = customerService;
        }


        public async Task OnGetAsync() {
            Customers = await _customerService.GetCustomersAsync();
        }


        public async Task OnPostAsync() {
            await _customerService.DeleteCustomerAsync(CustomerID);
            Customers = await _customerService.GetCustomersAsync();
        }
    }
}
