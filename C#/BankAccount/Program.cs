using System;

namespace MyBank {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Creating new bank account...");
            var account = new BankAccount("Cuit", 1000);

            Console.WriteLine($"The account with number {account.AccountNumber} was assigned to {account.OwnerName} with an initial balance of ${account.Balance}.");

            try {
                account.MakeDeposit(100, DateTime.Now, "Allowance");
                Console.WriteLine($"New balance: {account.Balance}");
            } catch (ArgumentOutOfRangeException) {
                Console.WriteLine("Deposit amount is less than $0.");
            }

            try {
                account.MakeWithdrawal(300, DateTime.Now, "Light bill");
                Console.WriteLine($"New balance: {account.Balance}");
            } catch (ArgumentOutOfRangeException ex) {
                Console.WriteLine(ex.Message);
            } catch (InvalidOperationException ex) {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(account.GetTransactionHistory());


            var interestEarningAccount = new InterestEarningAccount("Cuit", 1500);
            interestEarningAccount.MakeWithdrawal(100, DateTime.Now, "Candy");
            interestEarningAccount.PerformMonthEndTransactions();
            Console.WriteLine(interestEarningAccount.GetTransactionHistory());


            var LineOfCreditAccount = new LineOfCreditAccount("Cuit", 0, 2000);
            LineOfCreditAccount.MakeWithdrawal(3000, DateTime.Now, "Tacos");
            LineOfCreditAccount.MakeDeposit(100, DateTime.Now, "All I own");
            LineOfCreditAccount.PerformMonthEndTransactions();
            Console.WriteLine(LineOfCreditAccount.GetTransactionHistory());


            var GiftCardAccount = new GiftCardAccount("Cuit", 500, 50);
            GiftCardAccount.MakeWithdrawal(100, DateTime.Now, "Candy");
            GiftCardAccount.MakeWithdrawal(100, DateTime.Now, "Candy");
            GiftCardAccount.PerformMonthEndTransactions();
            Console.WriteLine(GiftCardAccount.GetTransactionHistory());
        }
    }
}
