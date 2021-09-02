using System;
using System.Collections.Generic;

namespace Fibonacci {
    class Program {
        static void Main(string[] args) {
            var fibonacci = new List<int>();
            var numbersCount = 20;

            for (int i = 0; i < numbersCount; i++) {
                if (fibonacci.Count > 0) {
                    var nextNumber = fibonacci[^1] + fibonacci[^2];
                    fibonacci.Add(nextNumber);
                } else {
                    fibonacci.Add(0);
                    fibonacci.Add(1);
                }
            }

            foreach (var item in fibonacci) {
                Console.WriteLine(item);
            }
        }
    }
}
