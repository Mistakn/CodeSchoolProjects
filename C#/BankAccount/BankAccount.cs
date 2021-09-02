using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank {
    public class BankAccount {


        public string AccountNumber { get; }
        public string OwnerName { get; }
        public decimal Balance {
            get {
                decimal balance = 0;

                foreach (var transactionElement in transactionHistory) {
                    balance += transactionElement.Amount;
                }

                return balance;
            }
        }


        private List<Transaction> transactionHistory = new List<Transaction>();
        private static int accountNumberSeed = 19141;
        private readonly decimal _minimumBalance;


        // Constructor
        public BankAccount(string ownerName, decimal initialBalance) : this(ownerName, initialBalance, 0) { }

        public BankAccount(string ownerName, decimal initialBalance, decimal minimumBalance) {

            this.OwnerName = ownerName;
            this._minimumBalance = minimumBalance;

            if (initialBalance > 0) {
                this.MakeDeposit(initialBalance, DateTime.Now, "Initial deposit");
            }

            this.AccountNumber = accountNumberSeed.ToString();
            accountNumberSeed++;
        }


        public void MakeDeposit(decimal depositAmount, DateTime date, string note) {
            if (depositAmount <= 0) {
                throw new ArgumentOutOfRangeException(nameof(depositAmount), "The deposit must be greater than 0.");
            }

            var transaction = new Transaction(depositAmount, date, note);
            transactionHistory.Add(transaction);

            Console.WriteLine($"Deposit for ${depositAmount} with note '{note}' was successfull.");
        }

        public void MakeWithdrawal(decimal withdrawalAmount, DateTime date, string note) {
            if (withdrawalAmount <= 0) {
                throw new ArgumentOutOfRangeException(nameof(withdrawalAmount), "The withdrawal must be greater than 0.");
            }

            //if (_minimumBalance > Balance - withdrawalAmount) {
            //    throw new InvalidOperationException("You do not have enough funds in your account.");
            //}

            //var transaction = new Transaction(-withdrawalAmount, date, note);
            //transactionHistory.Add(transaction);

            //Console.WriteLine($"Withdrawal for ${withdrawalAmount} with note '{note}' was successfull.");

            var overdraftTransaction = CheckWithdrawalLimit(_minimumBalance > Balance - withdrawalAmount);
            var withdrawal = new Transaction(-withdrawalAmount, date, note);
            transactionHistory.Add(withdrawal);

            if (overdraftTransaction != null) {
                transactionHistory.Add(overdraftTransaction);
            }
        }

        public virtual Transaction CheckWithdrawalLimit(bool isOverdrawn) {
            if (isOverdrawn) {
                throw new InvalidOperationException("Not enough line of credit.");
            } else {
                return default;
            }
        }

        public string GetTransactionHistory() {

            decimal balance = 0;
            var report = new StringBuilder();
            report.AppendLine("Date\t\tAmount\t\tNew Balance\tNotes");

            foreach (var transaction in transactionHistory) {
                balance += transaction.Amount;
                report.AppendLine(
                    $"{transaction.Date.ToShortDateString()}\t${transaction.Amount}\t\t${balance}\t\t{transaction.Note}"
                    );
            }

            return report.ToString();
        }


        public virtual void PerformMonthEndTransactions() {
            Console.WriteLine("Hello");
        }
    }
}
