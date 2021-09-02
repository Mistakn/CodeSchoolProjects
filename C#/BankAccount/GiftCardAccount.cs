using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank {
    class GiftCardAccount : BankAccount {

        private decimal _monthlyDeposit = 0;


        public GiftCardAccount(string ownerName, decimal initialBalance, decimal monthlyDeposit = 0) : base(ownerName, initialBalance) {
            _monthlyDeposit = monthlyDeposit;
        }


        public override void PerformMonthEndTransactions() {
            if (_monthlyDeposit != 0) {
                MakeDeposit(_monthlyDeposit, DateTime.Now, "Monthly gift deposit");
            }
        }

    }
}
