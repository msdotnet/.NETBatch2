
using DigitalBank.Extensions;
using DigitalBank.Services;

Console.WriteLine("\nWelcome to QualMinds Digital Bank\n");

// Open a bank account
var accountService = new AccountService();

Options:
AccountServiceOptions();
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

static void AccountServiceOptions()
{
   Console.WriteLine("\nPlease chose your account service by entering:" +
   "\n\n 'w' for withdrawal, \n 'd' for deposit or \n 't' for transaction history" +
   "\n\npress and enter any other key, if you want to exit...");
}
