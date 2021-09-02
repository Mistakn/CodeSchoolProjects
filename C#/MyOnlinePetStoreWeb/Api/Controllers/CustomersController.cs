using Microsoft.AspNetCore.Mvc;
using MyOnlinePetStoreWeb.Entities;
using MyOnlinePetStoreWeb.Models;
using MyOnlinePetStoreWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Api.Controllers {

    [ApiController]
    [Route("/api/[controller]")]
    public class CustomersController : Controller {


        private readonly IDbCustomerService _customerService;


        public CustomersController(IDbCustomerService customerService) {
            _customerService = customerService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Get() {
            return Ok(await _customerService.GetCustomersAsync());
        }



        [HttpPut("{id}/UpdateAddress")]
        public async Task<IActionResult> UpdateAddress(int id, AddressDTO address) {

            var customer = await _customerService.GetCustomerAsync(id);
            if (customer == null) {
                return NotFound();
            }

            try {
                await _customerService.UpdateCustomerAddressAsync(customer, address);
            } catch (Exception ex) {
                return BadRequest();
            }

            return Ok();
        }

    }
}