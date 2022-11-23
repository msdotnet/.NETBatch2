using DigitalBank.Core.Contracts;
using DigitalBank.Core.Entities;

namespace DigitalBank.Services
{
    internal class LoanAccountService
    {
        internal readonly ILoanAccount _account;

        internal LoanAccountService()
        {
            Console.Write("To open a loan account, please enter your first name: ");
            var firstName = Console.ReadLine();
            Console.Write("Please enter your last name: ");
            var lastName = Console.ReadLine();
            Console.Write("Please enter loan tenure (in years): ");
            var tenure = Convert.ToDouble(Console.ReadLine());
        InitialAmount:
            Console.Write("Please provide loan amount: ");
            var initialAmount = Convert.ToDecimal(Console.ReadLine());
            try
            {
                _account = new LoanAccount(new Amount() { Value = initialAmount, Currency = Currency.INR }, tenure, new Owner(firstName, lastName));
                Console.WriteLine($"\nCongratulations on opening a loan account with us.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                goto InitialAmount;
            }
            Console.WriteLine($"\n{_account.Summary}");
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
    }
}