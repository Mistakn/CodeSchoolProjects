using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaPizzeriaDeDonCangrejo {

    class Pizza {


        public string Size {
            get => _size;
        }
        public int NumCheese {
            get => _numCheese;
        }
        public int NumPepperoni {
            get => _numPepperoni;
        }
        public int NumHam {
            get => _numHam;
        }

        private string _size;
        private int _numCheese;
        private int _numPepperoni;
        private int _numHam;


        public Pizza(string size, int numCheese, int numPepperoni, int numHam) {
            this._size = size;
            this._numCheese = numCheese;
            this._numPepperoni = numPepperoni;
            this._numHam = numHam;
        }

        public double CalcCost() {

            var totalToppingsCost = (this.NumCheese + this.NumPepperoni + this.NumHam) * 2;

            if (this.Size == "Small") {
                return 10 + totalToppingsCost;
            } else if (this.Size == "Medium") {
                return 12 + totalToppingsCost;
            } else if (this.Size == "Large") {
                return 14 + totalToppingsCost;
            } else {
                throw new ArgumentOutOfRangeException("Pizza size must be 'Small', 'Medium' or 'Large'");
            }
        }

        public string GetDescription() {
            var pizzaDescription = new StringBuilder();

            pizzaDescription.AppendLine($"Pizza size: {this.Size}");
            pizzaDescription.AppendLine($"Number of Cheese Toppings: {this.NumCheese}");
            pizzaDescription.AppendLine($"Number of Pepperoni Toppings: {this.NumPepperoni}");
            pizzaDescription.AppendLine($"Number of Ham Toppings: {this.NumHam}");

            return pizzaDescription.ToString();
        }
    }
}
