using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Cuit";
            Console.WriteLine("Hello " + name + "!");

            // Interpolation example
            // $ es el caracter reservado para la interpolacion
            Console.WriteLine($"Hello {name}! Your name is {name.Length} characters long.");
            Console.WriteLine($"Your name is {(name.Length > 15 ? "very long" : "not very long")}.");
        }
    }
}
