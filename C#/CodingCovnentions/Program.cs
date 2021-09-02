using System;

namespace CodingCovnentions {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
        }
    }

    public class ExampleClass {

    }

    // Records are classes of unmutable data
    public record ExampleRecord();

    public interface IWorker {

    }

    public class Worker : IWorker {

        public bool isValid;

        private int _number;

        /// <summary>
        /// Waaaaa
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void MethodExample(int a, int b) {

        }

    }

}
