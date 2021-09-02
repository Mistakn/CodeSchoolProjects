using System;

namespace MyVehicles {
    class Program {
        static void Main(string[] args) {

            var taxi = new Car("Taxi", 200, 5, 5, "Yellow");
            taxi.ChangeColor("Black");
            taxi.ChargeFee();

            var schoolBus = new Bus("School bus", 100, 50, 10, "Gray", 50);
            schoolBus.ChangeColor("Yellow");
            schoolBus.ChargeFee();

        }
    }
}
