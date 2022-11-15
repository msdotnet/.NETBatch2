using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualMinds.Hrm.Core
{
   public class Employee
   {
      internal static int s_id;
      public string FirstName { get; set; }
      public string LastName { get; set; }
      /// <summary>
      /// Provides full name when first name and the last name is passed
      /// </summary>
      /// <param name="firstName"> Accepts first name of the employee</param>
      /// <param name="lastName"> Accepts lastName of the employee</param>
      /// <returns> Return full name</returns>
      public static string ReturnFullName(string firstName,
         string 
         lastName)
      {
         return $"{firstName} {lastName}";
      }
      
   }
   class Test
   {
      public static CallFullName()
      {
         Employee.
      }
   }
}
