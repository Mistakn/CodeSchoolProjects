using Microsoft.AspNetCore.Mvc;
using MyPizzaStoreAPI.Models;
using MyPizzaStoreAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPizzaStoreAPI.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class PizzasController : Controller {

        [HttpGet]
        public ActionResult<List<Pizza>> Get() {
            return PizzaService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id) {
            var pizza = PizzaService.Get(id);

            if (pizza == null) {
                return NotFound();
            }

            return pizza;
        }


        [HttpPost]
        public IActionResult Create(Pizza pizza) {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Create), new { ID = pizza.Id }, pizza);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza) {

            if (id != pizza.Id) {
                return NotFound();
            }

            var pizzaToUpdate = PizzaService.Get(id);
            if (pizzaToUpdate == null) {
                return NotFound();
            }

            PizzaService.Update(pizza);
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var pizzaToDelete = PizzaService.Get(id);
            if (pizzaToDelete == null) {
                return NotFound();
            }

            PizzaService.Delete(id);
            return Ok();
        }
    }
}
