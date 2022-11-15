using DigitalBank.Core.Contracts;

namespace DigitalBank.Core.Entities
{
    public class Account : IAccount
    {
        public ulong Number { get; private set; }
        public string OwnerFirstName { get; set; } = string.Empty;
        public string OwnerLastName { get; set; } = string.Empty;
        public decimal Balance
        {
            get
            {
                return _balance;
            }
        }
        private decimal _balance;
        private static ulong s_accountNumberSeed = 1000000000000000;
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public Account(Amount amount, string firstName, string lastName)
        {
            if (amount.Value < 500)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Opening balance needs to be 500 or more.");
            }
            this.Number = s_accountNumberSeed;
            OwnerFirstName = firstName;
            OwnerLastName = lastName;
            Deposit(amount, "Opening Balance");
            s_accountNumberSeed++;
        }
        public bool Deposit(Amount amount, string note)
        {
            if (amount.Value <= 0)
            {
                throw new ArgumentOutOfRangeException
                   (nameof(amount), "Amount being deposited must be greater than 0.");
            }
            _balance += amount.Value;
            Transactions.Add(new Transaction(amount, note, TransactionType.Credit));
            return true;
        }
        public bool Withdraw(Amount amount, string note)
        {
            if (amount.Value <= 0)
            {
                throw new ArgumentOutOfRangeException
                   (nameof(amount), "Amount being withdrawn must be greater than 0.");
            }
            if (Balance - amount.Value < 0)
            {
                throw new InvalidOperationException("You can't withdraw more than available balance.");
            }
            _balance -= amount.Value;
            Transactions.Add(new Transaction(amount, note, TransactionType.Debit));
            return true;
        }
    }
}
