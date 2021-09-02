using System;
using System.Collections.Generic;

namespace Lists {
    class Program {
        static void Main(string[] args) {
            List<string> names = new List<string>() { "Cuit", "Cuitlahuac" };

            Console.WriteLine("Write a name and press enter:");

            string inputName = Console.ReadLine();
            names.Add(inputName);

            names.Sort();

            var indexInsertedName = names.IndexOf(inputName);
            Console.WriteLine($"{inputName}'s index: {indexInsertedName}");

            foreach (var item in names) {
                Console.WriteLine(item);
            }
        }
    }
}
