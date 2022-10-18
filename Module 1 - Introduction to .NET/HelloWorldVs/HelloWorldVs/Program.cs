using System;
using HelloWorldVs.Library;

namespace HelloWorldVs
{
   internal class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Coded from Visual Studio");
         var divisionResult = ArithmeticOperations.Divide(10 , 1);
         Console.WriteLine($"Result of division: {divisionResult}");

         var dateOperations = new DateOperations();
         var beutifiedDate = dateOperations.BeutifyDate();
         Console.WriteLine($"Beutified Date: {beutifiedDate}");
         Console.ReadLine();
      }

   }
}
