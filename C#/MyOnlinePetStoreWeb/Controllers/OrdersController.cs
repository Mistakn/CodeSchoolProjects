using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyOnlinePetStoreWeb.Data;
using MyOnlinePetStoreWeb.Entities;
using MyOnlinePetStoreWeb.Models.ViewModels;
using MyOnlinePetStoreWeb.Services.Interfaces;

namespace MyOnlinePetStoreWeb.Controllers {
    public class OrdersController : Controller {
        private readonly IDbShopService _shopService;

        public OrdersController(IDbShopService shopService) {
            _shopService = shopService;
        }

        // GET: Orders
        public async Task<IActionResult> Index(string searchQuery) {

            var orders = await _shopService.GetOrdersAsync();
            var mostRecentOrder = orders.OrderByDescending(o => o.OrderPlaced).Take(1).FirstOrDefault();

            if (searchQuery != null) {
                orders = orders.Where(
                    o => (o.OrderID == int.Parse(searchQuery)) ||
                    (o.Customer.FirstName.Contains(searchQuery)) ||
                    (o.Customer.Email.Contains(searchQuery))).ToList();
            }

            var viewModel = new OrdersVM {
                Orders = orders,
                SearchQuery = searchQuery,
                MostRecentOrder = mostRecentOrder
            };

            return View(viewModel);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null || id == 0) {
                return NotFound();
            }

            var order = await _shopService.GetOrderAsync(id ?? default(int));

            if (order == null) {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public async Task<IActionResult> Create() {
            ViewData["CustomerID"] = new SelectList(await _shopService.GetCustomersAsync(), "CustomerID", "Email");
            return View();
        }

        // POST: Orders/Create
        // To protect from over posting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("OrderID,OrderPlaced,OrderFulfilled,Status,CustomerID")] Order order) {
        //    if (ModelState.IsValid) {
        //        _context.Add(order);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "Email", order.CustomerID);
        //    return View(order);
        //}

        // GET: Orders/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var mostRecentOrder = await _shopService.GetMostRecentOrderAsync();

            var order = await _shopService.GetOrderAsync(id ?? default(int));
            if (order == null) {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(await _shopService.GetCustomersAsync(), "CustomerID", "Email", order.CustomerID);

            var viewModel = new OrdersEditVM {
                Order = order,
                MostRecentOrder = mostRecentOrder
            };

            return View(viewModel);
        }

        // POST: Orders/Edit/5
        // To protect from over posting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("OrderID,OrderPlaced,OrderFulfilled,Status,CustomerID")] Order order) {
            if (int.Parse(id) != order.OrderID) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    await _shopService.UpdateOrderStatusAsync(order.Status, order);
                } catch (DbUpdateConcurrencyException) {
                    if (!await OrderExists(order.OrderID)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(await _shopService.GetCustomersAsync(), "CustomerID", "Email", order.CustomerID);

            var mostRecentOrder = await _shopService.GetMostRecentOrderAsync();

            var viewModel = new OrdersEditVM {
                Order = order,
                MostRecentOrder = mostRecentOrder
            };

            return View("Index", viewModel);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var order = await _shopService.GetOrderAsync(id ?? default(int));
            if (order == null) {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var order = await _shopService.GetOrderAsync(id);
            await _shopService.DeleteOrderAsync(order);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> OrderExists(int id) {
            return await _shopService.GetOrderAsync(id) != null;
        }
    }
}
