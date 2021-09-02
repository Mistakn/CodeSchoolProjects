using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehicles {
    class Vehicle {


        public string Name { get; set; }
        public double MaxSpeed { get; set; }
        public int Mileage { get; set; }
        public decimal Fee { get; set; }
        public string Color { get; set; }


        public Vehicle(string name, double maxSpeed, int mileage, decimal fee, string color) {
            this.Name = name;
            this.MaxSpeed = maxSpeed;
            this.Mileage = mileage;
            this.Fee = fee;
            this.Color = color;
        }


        public void ChangeColor(string color) {
            this.Color = color;
            Console.WriteLine($"The color of '{this.Name}' has been changed to {color}.");
        }


        public virtual void ChargeFee() {
            Console.WriteLine();
            var feeCost = this.Fee * this.Mileage;
            Console.WriteLine($"Your fee for this ride is: ${feeCost}");
        }

    }
}
