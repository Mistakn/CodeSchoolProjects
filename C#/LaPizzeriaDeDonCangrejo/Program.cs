using System;

namespace LaPizzeriaDeDonCangrejo {
    class Program {
        static void Main(string[] args) {

            var pizzaOrder = new PizzaOrder();

            var mediumPizza = new Pizza("Medium", 5, 10, 0);
            Console.WriteLine(mediumPizza.GetDescription());
            Console.WriteLine($"Cost of {mediumPizza.Size} Pizza: ${mediumPizza.CalcCost()}\n");
            pizzaOrder.AddPizzaToOrder(mediumPizza);

            var largePizza = new Pizza("Large", 10, 10, 10);
            Console.WriteLine(largePizza.GetDescription());
            Console.WriteLine($"Cost of {largePizza.Size} Pizza: ${largePizza.CalcCost()}\n");
            pizzaOrder.AddPizzaToOrder(largePizza);

            Console.WriteLine($"Total order cost: ${pizzaOrder.CalcTotal()}");
        }
    }
}
