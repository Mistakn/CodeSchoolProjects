using System;

namespace Ejercicio_2 {
    class Program {
        static void Main(string[] args) {

            var birthDate = "2/8/1996";

            Console.WriteLine($"Birthday: {birthDate}");
            Console.WriteLine($"Age in days: {CalcAgeInDays(birthDate)} days.");
        }

        public static string CalcAgeInDays(string birthDate) {

            var arrayBirthDate = birthDate.Split("/");
            var birthDateDay = Int32.Parse(arrayBirthDate[0]);
            var birthDateMonth = Int32.Parse(arrayBirthDate[1]);
            var birthDateYear = Int32.Parse(arrayBirthDate[2]);

            var birthDateDateTime = new DateTime(birthDateYear, birthDateMonth, birthDateDay);
            var today = new DateTime();

            return (birthDateDateTime - today).TotalDays.ToString();
        }
    }
}
