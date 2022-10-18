using System;
using Humanizer;

namespace HelloWorldVs.Library
{
   public class DateOperations
   {
      public string BeutifyDate()
      {
         var todayDate = DateTime.Now;
         return todayDate.AddDays(2).Humanize();
      }
   }
}
