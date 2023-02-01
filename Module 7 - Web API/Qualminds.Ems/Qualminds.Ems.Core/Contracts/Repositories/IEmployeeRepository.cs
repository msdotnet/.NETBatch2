using Qualminds.Ems.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualminds.Ems.Core.Contracts.Repositories
{
    public interface IEmployeeRepository
    {
      public Task<IEnumerable<Employee>> GetEmployeesAsyc();
      public Task<Employee> GetEmployeeByIdAsyc(int id);
      public Task<Employee> CreateEmployeeAsyc(Employee employee);
      public Task<bool> UpdateEmployeeAsyc(int id, Employee employee);
      public Task<bool> DeleteEmployeeAsyc(int id);
   }
}
