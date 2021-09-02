using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank {
    class InterestEarningAccount : BankAccount {


        public InterestEarningAccount(string ownerName, decimal initialBalance) : base(ownerName, initialBalance) {
        }


        public override void PerformMonthEndTransactions() {
            if (Balance > 500) {
                decimal interest = Balance * 0.05m;
                MakeDeposit(interest, DateTime.Now, "Monthly interest earning");
            }
        }

    }
}
