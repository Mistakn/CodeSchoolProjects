using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank {
    class LineOfCreditAccount : BankAccount {


        public LineOfCreditAccount(string ownerName, decimal initialBalance, decimal creaditLimit) : base(ownerName, initialBalance, -creaditLimit) {
        }


        //public override void MakeDeposit(decimal depositAmount, DateTime date, string note) {
        //    if (depositAmount <= 0) {
        //        throw new ArgumentOutOfRangeException(nameof(depositAmount), "The deposit must be greater than 0.");
        //    }

        //    var transaction = new Transaction(depositAmount, date, note);
        //    transactionHistory.Add(transaction);

        //    Console.WriteLine($"Deposit for ${depositAmount} with note '{note}' was successfull.");
        //}


        public override void PerformMonthEndTransactions() {
            if (Balance < 0) {
                var interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Monthly interest charge.");
            }
        }


        public override Transaction CheckWithdrawalLimit(bool isOverdrawn) {
            return isOverdrawn ? new Transaction(-20, DateTime.Now, "Overdrawn charge") : null;
        }
    }
}
