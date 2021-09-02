using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExtensions {

    internal class Program {

        private static void Main(string[] args) {
            //var list1 = new List<int> { 1, 2, 3 };
            //var list2 = new List<int> { 1, 2, 3 };
            //var list3 = new List<int> { 1, 2, 53 };

            //// Compare lists
            //bool res1 = list1.SequenceEqual(list2);
            //bool res2 = list3.SequenceEqual(list2);

            //Console.WriteLine($"{(res1 ? "Lista 1 y 2 son iguales" : "Lista 1 y 2 no son iguales")}");
            //Console.WriteLine($"{(res2 ? "Lista 2 y 3 son iguales" : "Lista 2 y 3 no son iguales")}");

            //// Spread operator
            //list1.AddRange(list2);
            //Console.WriteLine(String.Join(", ", list1));

            //// Remove same results
            //list1 = list1.Distinct().ToList();
            //Console.WriteLine(String.Join(", ", list1));

            //// Get first result of condition (also applies to last)
            //var num1 = list1.First(firstNumber => firstNumber == 2);
            //Console.WriteLine(num1);

            //bool hasElements = list1.Any();
            //Console.WriteLine(hasElements);

            //bool has3 = list1.Any(number => number == 3);
            //Console.WriteLine(has3);

            // Exercises

            // B.1 Find the string which starts and ends with a specific character : AM
            // B.2 Write a program in C# Sharp to display the list of items in the array according to the length of the string then by name in ascending order.
            // B.3 Write a program in C# Sharp to split a collection of strings into 3 random groups.
            string[] cities =
            {
                "ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS"
            };

            var b1 = cities.Where(city => city.StartsWith("AM") && city.EndsWith("AM"));
            Console.WriteLine("B.1 Find the string which starts and ends with a specific character : 'AM'");
            Console.WriteLine($"B1: {String.Join(", ", b1)}");
            Console.WriteLine();


            var b2 = cities.OrderBy(city => city.Length);
            Console.WriteLine("B.2 Write a program in C# Sharp to display the list of items in the array according to the length of the string then by name in ascending order.");
            Console.WriteLine($"B2: {String.Join(", ", b2)}");
            Console.WriteLine();


            var b3 = cities.GroupBy(city => city[0]).Take(3);
            Console.WriteLine("Write a program in C# Sharp to split a collection of strings into 3 random groups.");
            foreach (var cityGroup in b3) {
                Console.WriteLine($"B3 group: {String.Join(", ", cityGroup)}");
            }
            Console.WriteLine();


            // C.1 Write a program in C# Sharp to display the number and frequency of number from given array.
            // C.2 Write a program in C# Sharp to display a list of unrepeated numbers.
            // C.3 Write a program in C# Sharp to display numbers, multiplication of number with frequency and the frequency of number of giving array.
            int[] arr1 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };

            int numberToFind = 3;
            var c1 = arr1.Where(number => number == numberToFind).Count();
            Console.WriteLine("C.1 Write a program in C# Sharp to display the number and frequency of number from given array.");
            Console.WriteLine($"The number '{numberToFind}' appears {c1} time(s).");
            Console.WriteLine();

            var c2 = arr1.Distinct();
            Console.WriteLine("C.2 Write a program in C# Sharp to display a list of unrepeated numbers.");
            Console.WriteLine(String.Join(", ", c2));
            Console.WriteLine();

            Console.WriteLine("C.3 Write a program in C# Sharp to display numbers, multiplication of number with frequency and the frequency of number of giving array.");
            var c3 = c2.Select(number => {
                var ocurrences = arr1.Where(numberInList => numberInList == number).Count();
                return $"The number {number} appears {ocurrences} time(s), {number}x{ocurrences}={number * ocurrences}";
            });
            foreach (var item in c3) {
                Console.WriteLine(item);
            }
            Console.WriteLine();



            // D.1 Get the top student of the list making an average of their scores.
            // D.2 Get the student with the lowest average score.
            // D.3 Get the last name of the student that has the ID 117
            List<Student> students = new List<Student>
            {
                new Student {FirstName="Svetlana", LastName="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
                new Student {FirstName="Claire", LastName="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
                new Student {FirstName="Sven", LastName="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
                new Student {FirstName="Cesar", LastName="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
                new Student {FirstName="Debra", LastName="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
                new Student {FirstName="Fadi", LastName="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
                new Student {FirstName="Hanying", LastName="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
                new Student {FirstName="Hugo", LastName="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
                new Student {FirstName="Lance", LastName="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
                new Student {FirstName="Terry", LastName="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
                new Student {FirstName="Eugene", LastName="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
                new Student {FirstName="Michael", LastName="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
            };

            var d1 = students.Select(student => {
                var averageScore = student.Scores.Average();
                return new { studentFullName = $"{student.FirstName} {student.LastName}", averageScore };
            }).OrderByDescending(student => student.averageScore).ToArray();

            // D1
            Console.WriteLine("D.1 Get the top student of the list making an average of their scores.");
            Console.WriteLine($"The top student is {d1.First().studentFullName} with an average score of: {d1.First().averageScore}");
            Console.WriteLine();

            // D2
            Console.WriteLine("D.2 Get the student with the lowest average score.");
            Console.WriteLine($"The student with the lowest average score is {d1.Last().studentFullName} with an average score of: {d1.Last().averageScore}");
            Console.WriteLine();

            // D3
            Console.WriteLine("Get the last name of the student that has the ID 117");
            var d3 = students.Where(student => student.ID == 117).Select(student => student.LastName).Single();
            Console.WriteLine($"The last name of the student with ID 117 is {d3}");
            Console.WriteLine();

        }
    }
}