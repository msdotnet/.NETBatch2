namespace DigitalBank.Core.Entities
{
   public record Owner(string FirstName, string LastName)
   {
      public string FullName => $"{FirstName} {LastName}";
   }
}