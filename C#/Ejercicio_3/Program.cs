using System;
using System.Text.RegularExpressions;

namespace Ejercicio_3 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(ValidatePIN("1234"));
            Console.WriteLine(ValidatePIN("123a"));
            Console.WriteLine(ValidatePIN("123456"));
            Console.WriteLine(ValidatePIN("12345"));
            Console.WriteLine(ValidatePIN("123."));
        }

        static bool ValidatePIN(string pin) {

            var isNumber = int.TryParse(pin, out int numberPIN);

            if (isNumber) {
                return (pin.Length == 4 || pin.Length == 6);
            } else {
                return false;
            }

            // return Regex.IsMatch(pin, "^[0-9]{4}$") || Regex.IsMatch(pin, "^[0-9]{6}$");
        }
    }
}
