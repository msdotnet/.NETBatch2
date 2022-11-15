using DigitalBank.Core.Entities;

namespace DigitalBank.Core.Contracts
{
    public interface IAccount
    {
        decimal Balance { get; }
        ulong Number { get; }
        string OwnerFirstName { get; set; }
        string OwnerLastName { get; set; }
        List<Transaction> Transactions { get; set; }
        bool Deposit(Amount amount, string note);
        bool Withdraw(Amount amount, string note);
    }
}