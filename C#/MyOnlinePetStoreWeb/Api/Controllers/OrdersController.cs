using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyOnlinePetStoreWeb.Api.Models.Orders;
using MyOnlinePetStoreWeb.Data;
using MyOnlinePetStoreWeb.Entities;
using MyOnlinePetStoreWeb.Models.Identity;
using MyOnlinePetStoreWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlinePetStoreWeb.Api.Controllers {

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller {


        private readonly IDbShopService _shopService;
        private readonly IDbCustomerService _customerService;
        private readonly UserManager<PetStoreIdentityUser> _userManager;


        public OrdersController(IDbShopService shopService, IDbCustomerService customerService, UserManager<PetStoreIdentityUser> userManager) {
            _shopService = shopService;
            _customerService = customerService;
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get() {
            var orders = await _shopService.GetOrdersAsync();
            return Ok(orders);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id) {
            var order = await _shopService.GetOrderAsync(id);
            return Ok(order);
        }


        [HttpPost("AddProductToOrder")]
        public async Task<IActionResult> AddProductToOrder(AddProductToOrderDTO addProductToOrderDTO) {

            var user = await _userManager.GetUserAsync(User);

            if (!user.CustomerId.HasValue) {
                return BadRequest("Customer doesn't exist");
            }

            var customer = await _customerService.GetCustomerAsync(user.CustomerId.Value);

            // Check to see if customer has an ongoing order
            Order ongoingOrder = customer.GetOngoingOrder();

            if (!(ongoingOrder is Order)) {
                // Customer doesn't have an ongoing order, create new 
                Order order = new(customer.CustomerID, addProductToOrderDTO.ProductId, addProductToOrderDTO.Quantity, OrderStatusesEnum.Pending.ToString());
                //order.AddProduct(2, 5);

                try {
                    await _shopService.AddOrderToCustomerAsync(customer, order);
                    Console.WriteLine("Client order updated");
                } catch (Exception ex) {
                    Console.WriteLine($"Error: {ex.Message}");
                    return new NotFoundResult();
                }

                return Ok();

            } else {
                // Customer has ongoing order, check if product doesn't exist in order yet
                var productIsInOrder = ongoingOrder.ProductIsInOrder(addProductToOrderDTO.ProductId);

                if (!productIsInOrder) {
                    // If product isn't in order, add product to order
                    ProductOrder productOrder = new() {
                        ProductID = addProductToOrderDTO.ProductId,
                        Quantity = addProductToOrderDTO.Quantity
                    };

                    try {
                        await _shopService.AddProductToOrderAsync(ongoingOrder, productOrder);
                    } catch (Exception ex) {
                        Console.WriteLine($"Error: {ex.Message}");
                        return new NotFoundResult();
                    }

                    return Ok();
                }

                return BadRequest();
            }
        }


        [HttpPut("UpdateOrderProductQuantityAsync")]
        public async Task<IActionResult> UpdateOrderProductQuantityAsync(UpdateOrderProductQuantityDTO updateOrderProductQuantityDTO) {
            var customer = await _customerService.GetCustomerAsync(updateOrderProductQuantityDTO.UserId);

            // Check to see if customer has an ongoing order
            Order ongoingOrder = customer.GetOngoingOrder();
            if (ongoingOrder == null) {
                return BadRequest();
            }

            try {
                await _shopService.UpdateOrderProductQuantityAsync(ongoingOrder, updateOrderProductQuantityDTO.ProductID, updateOrderProductQuantityDTO.Quantity);
            } catch (Exception ex) {
                return new NotFoundResult();
            }

            return Ok();
        }


        [HttpPut("Complete")]
        public async Task<IActionResult> Complete(int userId) {
            var customer = await _customerService.GetCustomerAsync(userId);

            // Check to see if customer has an ongoing order
            Order ongoingOrder = customer.GetOngoingOrder();
            if (ongoingOrder == null) {
                return BadRequest();
            }

            try {
                await _shopService.CompleteOrderAsync(ongoingOrder);
            } catch (Exception ex) {
                return new NotFoundResult();
            }

            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int userId) {
            var customer = await _customerService.GetCustomerAsync(userId);

            // Check to see if customer has an ongoing order
            Order ongoingOrder = customer.GetOngoingOrder();
            if (ongoingOrder == null) {
                return BadRequest();
            }

            try {
                await _shopService.DeleteOrderAsync(ongoingOrder);
            } catch (Exception ex) {
                return new NotFoundResult();
            }

            return Ok();
        }


    }
}
