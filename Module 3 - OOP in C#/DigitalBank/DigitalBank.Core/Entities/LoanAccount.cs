using DigitalBank.Core.Contracts;

namespace DigitalBank.Core.Entities
{
    public class LoanAccount : Account, ILoanAccount
    {
        private static ulong s_accountNumberSeed = 5000000000000000;
        private readonly double _emi;
        public double Amount { get; private set; }
        public double Emi { get => Math.Round(_emi, 2); }
        public double Tenure { get; init; }
        public const double InterestRate = 8.4;

        public override string Summary
        {
            get
            {
                var summaryHeader = "Account Number\t\tOwner\t\tAmount\tTenure\tRate\tEMI(Monthly)\tBalance";
                var summaryBody = $"{Number}\t{Owner.FullName}\t{Amount}\t{Tenure}\t{InterestRate}\t{Emi}\t\t{Balance}";
                return $"{summaryHeader}\n{summaryBody}";
            }
        }

        public LoanAccount(Amount amount, double tenure, Owner owner) : base(owner)
        {
            base.Number = s_accountNumberSeed;
            Withdraw(amount, "Loan disbursed.");
            s_accountNumberSeed++;
            Amount = (double)amount.Value;
            Tenure = tenure;
            _emi = CalculateEmi();
        }

        protected new bool Withdraw(Amount amount, string note)
        {
            if (amount.Value <= 0)
            {
                throw new ArgumentOutOfRangeException
                   (nameof(amount), "Amount being withdrawn must be greater than 0.");
            }
            _balance -= amount.Value;
            Transactions.Add(new Transaction(amount, note, TransactionType.Debit));
            return true;
        }

        public double CalculateEmi()
        {
            double r = InterestRate / (12 * 100);
            double t = Tenure * 12;
            return (Amount * r * Math.Pow(1 + r, t)) / (Math.Pow(1 + r, t) - 1);
        }
    }
}