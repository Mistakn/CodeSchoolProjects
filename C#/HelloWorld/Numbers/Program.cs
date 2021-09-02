using System;

namespace Numbers
{
    class Program {
        static void Main(string[] args) {

            string name = "Cuit";
            string[] names = new string[] { "Cuit", "Cuitlahuac" };
            
            int a = 4;
            int b = 5;

            bool greaterThan = a > b;

            double c = double.MaxValue;
            double d = double.MinValue;

            // Las variables de tipo Decimal son utiles para cuando se esta manejando dinero
            decimal money = 1;

            Console.WriteLine($"A: {a}, B: {b}");

            if(greaterThan) {
                Console.WriteLine($"{a} is bigger then {b}");
            } else {
                Console.WriteLine($"{a} is smaller then {b}");
            }

            switch(name) {

                case "Cuit":
                    Console.WriteLine($"Hi {name}");
                    break;


                default:
                    Console.WriteLine($"Name not found :c");
                    break;
            }

            for (int i = 0; i < a; i++) {
                Console.WriteLine($"{i}");
            }

            foreach (string item in names) {
                Console.WriteLine($"{item}");
            }

            int counter = 0;
            while (counter <= 5) {
                Console.WriteLine($"{counter}");
                counter++;
            }

            counter = 0;
            do {
                Console.WriteLine($"{counter}");
                counter++;
            } while (counter <= 5);

            Console.WriteLine($"C: {c}, D: {d}");
        }
    }
}
