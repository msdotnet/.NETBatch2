using Microsoft.EntityFrameworkCore;
using Qualminds.Ems.Core.Contracts.Repositories;
using Qualminds.Ems.Core.Entities;
using Qualminds.Ems.Infrastructure.Data;
using System.Reflection.Metadata;

namespace Qualminds.Ems.Infrastructure.Repositories
{
   public class EmployeeRepository : IEmployeeRepository
   {
      private readonly EmployeeDbContext _dbContext;

      public EmployeeRepository(EmployeeDbContext dbContext)
      {
         this._dbContext = dbContext;
      }

      public async Task<Employee> CreateEmployeeAsyc(Employee employee)
      {
         _dbContext.Employees.Add(employee);
         await _dbContext.SaveChangesAsync();
         return employee;
      }

      public async Task<bool> DeleteEmployeeAsyc(int id)
      {
         var employeeToDeleted = await _dbContext.Employees.FindAsync(id);
         if (employeeToDeleted is null)
            return false;
         _dbContext.Employees.Remove(employeeToDeleted);
         var result = await _dbContext.SaveChangesAsync();
         return result >= 1;
      }

      public async Task<Employee> GetEmployeeByIdAsyc(int id)
      {
         return await _dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(_ => _.Id == id);
      }

      public async Task<IEnumerable<Employee>> GetEmployeesAsyc()
      {
         return await _dbContext.Employees.AsNoTracking().ToListAsync();
      }

      public async Task<bool> UpdateEmployeeAsyc(int id, Employee employee)
      {
         //var employeeToBeUpdated = await GetEmployeeByIdAsyc(id);
         //if (employeeToBeUpdated is null)
         //   return false;
         //employeeToBeUpdated.Name = employee.Name;
         //employeeToBeUpdated.Salary = employee.Salary;
         //employeeToBeUpdated.Email = employee.Email;
         //employeeToBeUpdated.DepartmentId = employee.DepartmentId;
         //_dbContext.Employees.Update(employeeToBeUpdated);
         _dbContext.Entry(employee).State = EntityState.Modified;
         var result = await _dbContext.SaveChangesAsync();
         return result >= 1;
      }
   }
}
