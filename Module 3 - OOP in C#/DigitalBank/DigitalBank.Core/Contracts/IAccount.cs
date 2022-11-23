using DigitalBank.Core.Entities;

namespace DigitalBank.Core.Contracts
{
    public interface IAccount
    {
        decimal Balance { get; }
        ulong Number { get; }
        Owner Owner { get; set; }
        string Summary { get; }
        List<Transaction> Transactions { get; set; }

        bool Deposit(Amount amount, string note);

        bool Withdraw(Amount amount, string note);
    }
}