using DigitalBank.Extensions;
using DigitalBank.Services;

Console.WriteLine("\nWelcome to QualMinds Digital Bank\n");

Console.WriteLine("Opening an account with us? " +
   "please chose the account type by entering:\n\n 's' for Saving, \n 'l' for loan");

var accountType = Console.ReadLine();

switch (accountType)
{
   case "s":
      RunSavingAccount();
      break;

   case "l":
      RunLoanAccount();
      break;
}

static void RunSavingAccount()
{
   // Open a bank account
   var accountService = new SavingAccountService();
Options:
   SavingAccountServiceOptions();

   string? chosenService = Console.ReadLine();

   switch (chosenService)
   {
      case "d":
         accountService.Deposit();
         goto Options;
      case "w":
         accountService.Withdraw();
         goto Options;
      case "t":
         Console.WriteLine($"\nTransaction History: \n\n{accountService._account.Transactions.GetTransactionHistory()}");
         goto Options;
      default:
         Console.WriteLine("End of Banking");
         break;
   }
}

static void RunLoanAccount()
{
   // Open a bank account
   var accountService = new LoanAccountService();
Options:
   LoanAccountServiceOptions();

   string? chosenService = Console.ReadLine();

   switch (chosenService)
   {
      case "d":
         accountService.Deposit();
         goto Options;
      case "t":
         Console.WriteLine($"\nTransaction History: \n\n{accountService._account.Transactions.GetTransactionHistory()}");
         goto Options;
      default:
         Console.WriteLine("End of Banking");
         break;
   }
}

static void SavingAccountServiceOptions()
{
   Console.WriteLine("\nPlease chose your account service by entering:" +
   "\n\n 'w' for withdrawal, \n 'd' for deposit or \n 't' for transaction history" +
   "\n\npress and enter any other key, if you want to exit...");
}

static void LoanAccountServiceOptions()
{
   Console.WriteLine("\nPlease chose your loan account service by entering:" +
   "\n\n 'd' for deposit or \n 't' for transaction history" +
   "\n\npress and enter any other key, if you want to exit...");
}