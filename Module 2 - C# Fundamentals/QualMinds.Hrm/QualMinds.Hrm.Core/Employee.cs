namespace QualMinds.Hrm.Core
{
   public class Employee
   {
      public const string Organization = "QualMinds";

      private protected string FirstName;
      protected internal string LastName { get; set; }
      public Employee()
      {
         this.FirstName = "Default Name";
         this.LastName = "Default Surame";
      }
      public Employee(string firstName, string lastName)
      {
         if(string.IsNullOrEmpty(firstName))
            throw new ArgumentNullException(nameof(firstName), "First name must be non nullable")
         Organization = "QM"; 
         this.FirstName = firstName;
         this.LastName = lastName;
      }

      public string GetFullName ()
      {

         return $"Length of the first name: {FirstName?.Length} and the last name is: {LastName}";
      }
      public class Department
      {
         public string Id { get; set; }
         public string Name { get; set; }
      }
   }
}