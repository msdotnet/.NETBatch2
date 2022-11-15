namespace DigitalBank.Core.Entities
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public Amount Amount { get; set; }
        public string? Note { get; set; }
        public TransactionType Type { get; set; }

        public Transaction(Amount amount, string note, TransactionType type)
        {
            Amount = amount;
            Date = DateTime.Now;
            Note = note;
            Type = type;
        }
        //public override string? ToString()
        //{
        //   // Can be removed. Keeping here for educational purpose only.
        //   return $"{Date}\t{Amount}\tBalance\t{Note}";
        //}
    }

    public struct Amount
    {
        public decimal Value { get; set; }
        public Currency Currency { get; set; }
    }
    public enum Currency : short
    {
        INR = 1,
        USD,
        GBP
    }
    public enum TransactionType : byte
    {
        Credit = 1,
        Debit
    }
}
