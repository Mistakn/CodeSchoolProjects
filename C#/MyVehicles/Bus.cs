using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehicles {
    class Bus : Vehicle {


        public int Capacity { get; set; }


        public Bus(string name, double maxSpeed, int mileage, decimal fee, string color, int capacity) : base(name, maxSpeed, mileage, fee, color) {
            this.DetermineCapacity(capacity);
            Console.WriteLine($"Bus capacity: {Capacity}");
        }


        public void DetermineCapacity(int capacity) {
            this.Capacity = capacity;
        }


        public override void ChargeFee() {
            var feeCost = this.Fee / this.Capacity;
            Console.WriteLine($"Your fee for this ride is: ${feeCost}");
        }
    }
}
