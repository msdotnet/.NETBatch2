using System;

namespace HelloWorldVs
{
   internal class Program
   {
      static void Main(string[] args)
      {
         var helloWorldText = "Result of division: ";
         var result = Divide(10 , 1);
         Console.WriteLine(helloWorldText + result);
         Console.WriteLine("Coded from Visual Studio");
         Console.ReadLine();
      }
      static int Divide(int a, int b)
      {
         return a / b;
      }
   }
}
