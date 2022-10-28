using QualMinds.Hrm.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualMinds.Hrm
{
   internal class EmployeeChild : Employee
   {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public EmployeeChild()
      {
         this.FirstName = base.FirstName;
         this.LastName = base.LastName;
      }
   }
}
