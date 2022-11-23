using DigitalBank.Core.Contracts;

namespace DigitalBank.Core.Entities
{
    public abstract class Account : IAccount
    {
        public ulong Number { get; protected set; }
        public Owner Owner { get; set; }

        public decimal Balance
        {
            get
            {
                return _balance;
            }
        }

        public abstract string Summary { get; }
        protected decimal _balance;
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public Account(Owner owner)
        {
            Owner = owner;
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

        public virtual bool Withdraw(Amount amount, string note)
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