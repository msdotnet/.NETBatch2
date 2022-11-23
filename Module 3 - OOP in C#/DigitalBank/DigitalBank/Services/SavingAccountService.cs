using DigitalBank.Core.Entities;

namespace DigitalBank.Services
{
    internal class SavingAccountService
    {
        internal readonly Account _account;

        internal SavingAccountService()
        {
            Console.Write("To open a saving account, please enter your first name: ");
            var firstName = Console.ReadLine();
            Console.Write("Please enter your last name: ");
            var lastName = Console.ReadLine();
        InitialAmount:
            Console.Write("Please provide initial deposit amount: ");
            var initialAmount = Convert.ToDecimal(Console.ReadLine());
            try
            {
                _account = new SavingAccount(new Amount() { Value = initialAmount, Currency = Currency.INR }, new Owner(firstName, lastName));
                Console.WriteLine($"\nCongratulations on opening an account with us with an opening balance of {_account.Balance}.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                goto InitialAmount;
            }
            Console.WriteLine($"\nAccount Summary:\n{_account.Summary}");
        }

        internal void Deposit()
        {
            Console.Write("Please provide deposit amount: ");
            var depositAmount = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Deposit note: ");
            var depositNote = Console.ReadLine();
        Deposit:
            try
            {
                _account.Deposit(new Amount() { Value = depositAmount, Currency = Currency.INR }, depositNote);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write("\nPlease provide a valid deposit amount: ");
                depositAmount = Convert.ToDecimal(Console.ReadLine());
                goto Deposit;
            }

            Console.WriteLine($"\n{_account.Summary}");
        }

        internal void Withdraw()
        {
            Console.Write("Please provide withdrawal amount: ");
            var withdrawalAmount = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Withdrawal note: ");
            var withdrawalNote = Console.ReadLine();
        Withdraw:
            try
            {
                _account.Withdraw(new Amount() { Value = withdrawalAmount, Currency = Currency.INR }, withdrawalNote);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write("\nPlease provide a valid withdrawal amount: ");
                withdrawalAmount = Convert.ToDecimal(Console.ReadLine());
                goto Withdraw;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write("\nPlease provide a valid withdrawal amount: ");
                withdrawalAmount = Convert.ToDecimal(Console.ReadLine());
                goto Withdraw;
            }
            Console.WriteLine($"\n{_account.Summary}");
        }
    }
}