using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehicles {
    class Car : Vehicle {


        public Car(string name, double maxSpeed, int mileage, decimal fee, string color) : base(name, maxSpeed, mileage, fee, color) {
            Console.WriteLine($"Vehicle: {this.Name}");
            Console.WriteLine($"{this.Name} max speed: {this.MaxSpeed}");
            Console.WriteLine($"{this.Name} mileage: {this.Mileage}");
            Console.WriteLine($"{this.Name} color: {this.Color}");
            Console.WriteLine();
        }


    }
}
