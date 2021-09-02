using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaPizzeriaDeDonCangrejo {
    class PizzaOrder {


        public List<Pizza> order = new List<Pizza>(3);


        public void AddPizzaToOrder(Pizza pizza) {
            order.Add(pizza);
        }


        public double CalcTotal() {
            double total = 0;

            foreach (var pizza in order) {
                total += pizza.CalcCost();
            }

            return total;
        }

    }
}
