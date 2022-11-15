using DigitalBank.Core.Entities;
using System.Text;
using Entities = DigitalBank.Core.Entities;

namespace DigitalBank.Extensions
{
   public static class TransactionExtensions
   {
      public static string GetTransactionHistory(this List<Entities.Transaction> transactions)
      {
         decimal balance = 0;
         var transactionHistory = new StringBuilder();
         transactionHistory.AppendLine($"Date\t\t\tAmount\tCurrency\tBalance\tType\tNote");
         foreach (var transaction in transactions)
         {
            switch (transaction.Type)
            {
               case TransactionType.Debit:
                  balance -= transaction.Amount.Value;
                  break;
               case TransactionType.Credit:
                  balance += transaction.Amount.Value;
                  break;
            }
            transactionHistory.AppendLine($"{transaction.Date}\t{transaction.Amount.Value}\t{transaction.Amount.Currency.ToString()}\t\t{balance}\t{transaction.Type.ToString()}\t{transaction.Note}");
         }
         return transactionHistory.ToString();
      }
   }
}
