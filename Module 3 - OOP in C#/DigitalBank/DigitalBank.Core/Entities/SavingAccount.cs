using DigitalBank.Core.Contracts;

namespace DigitalBank.Core.Entities
{
    public sealed class SavingAccount : Account, ISavingAccount
    {
        private static ulong s_accountNumberSeed = 1000000000000000;

        public override string Summary
        {
            get
            {
                var summaryHeader = "Account Number\t\tOwner\t\tBalance";
                var summaryBody = $"{Number}\t{Owner.FullName}\t{Balance}";
                return $"{summaryHeader}\n{summaryBody}";
            }
        }

        public SavingAccount(Amount amount, Owner owner) : base(owner)
        {
            if (amount.Value < 500)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Opening balance needs to be 500 or more.");
            }
            Number = s_accountNumberSeed;
            Deposit(amount, "Opening Balance");
            s_accountNumberSeed++;
        }
    }
}