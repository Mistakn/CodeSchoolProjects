using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_1 {
    class Program {
        static void Main(string[] args) {


            var array = new List<int>() { 1, 2, 3, 4, 5 };
            var reversedArray = new List<int>();


            for (int i = 0; i < array.Count; i++) {
                reversedArray.Add(array[^(i + 1)]);
            }


            var arrayTextBuilder = new StringBuilder();
            arrayTextBuilder.Append("[ ");
            for (int i = 0; i < array.Count; i++) {
                var item = array[i];
                arrayTextBuilder.Append($"{item} ");
            }
            arrayTextBuilder.Append(']');

            Console.WriteLine("Original array:");
            Console.WriteLine(arrayTextBuilder);


            var reversedArrayTextBuilder = new StringBuilder();
            reversedArrayTextBuilder.Append("[ ");
            for (int i = 0; i < reversedArray.Count; i++) {
                var item = reversedArray[i];
                reversedArrayTextBuilder.Append($"{item} ");
            }
            reversedArrayTextBuilder.Append(']');

            Console.WriteLine("Reversed array:");
            Console.WriteLine(reversedArrayTextBuilder);
        }
    }
}
