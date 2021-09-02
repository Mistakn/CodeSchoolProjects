using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncProgramming {
    class Program {
        static async Task Main(string[] args) {

            CoffeeCup coffeeCup = PourCoffee();
            Console.WriteLine("Coffee has been served");

            Task<Egg> eggs = FryEggsAsync(2);

            Task<Bacon> bacon = FryBaconAsync(3);

            Toast toast = await PrepareToastWithButterAndJamAsync(2);

            Juice orangeJuice = await ServeOrangeJuiceAsync();
            Console.WriteLine("Juice is ready");

            Console.WriteLine("Breakfast is ready");


            var breakfastTasks = new List<Task> { eggs, bacon };

            while (breakfastTasks.Count > 0) {
                Task finishedTask = await Task.WhenAny(breakfastTasks);

                if (finishedTask == eggs) {
                    Console.WriteLine("Eggs are ready");
                } else if (finishedTask == bacon) {
                    Console.WriteLine("Slices of bacon are ready");
                }
            }
        }

        private static async Task<Toast> PrepareToastWithButterAndJamAsync(int slices) {
            Toast toast = await ToastBreadAsync(2);
            await ApplyButterAndJamAsync(toast);
            Console.WriteLine("Toast is ready");
            return toast;
        }

        private static async Task<Juice> ServeOrangeJuiceAsync() {
            Console.WriteLine("Pouring orange juice");
            await Task.Delay(3000);
            Console.WriteLine("Serving orange juice");
            return new Juice();
        }

        private static async Task ApplyButterAndJamAsync(Toast toast) {
            Console.WriteLine("Applying butter to toast");
            await Task.Delay(3000);
            Console.WriteLine("Applying jam to toast");
            await Task.Delay(3000);
            Console.WriteLine("Serving toast");
        }

        private static async Task<Toast> ToastBreadAsync(int slices) {
            Console.WriteLine("Toasting bread.");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");
            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices) {
            Console.WriteLine("Frying bacon.");
            await Task.Delay(3000);
            for (int i = 0; i < slices; i++) {
                Console.WriteLine("Flipping bacon over");
            }
            Console.WriteLine("Serving bacon");
            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany) {
            Console.WriteLine("Beating eggs and heating pan.");
            await Task.Delay(2000);
            Console.WriteLine("Frying eggs.");
            await Task.Delay(howMany * 1000);
            Console.WriteLine("Serving eggs");
            return new Egg();
        }


        private static CoffeeCup PourCoffee() {
            Console.WriteLine("Serving coffee.");
            return new CoffeeCup();
        }
    }
}
