using Microsoft.AspNetCore.Mvc;
using Qualminds.Ems.Core.Contracts.Repositories;
using Qualminds.Ems.Core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Qualminds.Ems.Api.Controllers
{
   [Route("[controller]")]
   [ApiController]
   public class EmployeesController : ControllerBase
   {
      private readonly IEmployeeRepository _employeeRepository;

      public EmployeesController(IEmployeeRepository employeeRepository)
      {
         this._employeeRepository = employeeRepository;
      }
      [HttpGet]
      public async Task<ActionResult> Get()
      {
         var result = await _employeeRepository.GetEmployeesAsyc();
         return Ok(result);
      }

      [HttpGet("{id}")]
      public async Task<ActionResult> Get(int id)
      {
         var result = await _employeeRepository.GetEmployeeByIdAsyc(id);
         if (result is null)
            return NotFound();
         return Ok(result);
      }

      [HttpPost]
      public async Task<ActionResult> Post([FromBody] Employee employee)
      {
         var result = await _employeeRepository.CreateEmployeeAsyc(employee);
         if(result.Id is 0)
            return BadRequest();
         return CreatedAtAction(nameof(Post), new {id = result.Id}, result);
      }

      [HttpPut("{id}")]
      public async Task<ActionResult> Put(int id, [FromBody] Employee employee)
      {
         if(employee.Id <= 0 || id != employee.Id)
               return BadRequest("Id is invalid");
         var result = await _employeeRepository.UpdateEmployeeAsyc(id, employee);
         if(!result)
            return BadRequest("Failed to update the changes, try again with valid request.");
         return NoContent();
      }

      [HttpDelete("{id}")]
      public async Task<ActionResult> Delete(int id)
      {
         if (id <= 0)
            return BadRequest("Id is invalid");
         var result = await _employeeRepository.DeleteEmployeeAsyc(id);
         if (!result)
            return BadRequest("Failed to update the changes, try again with valid request.");
         return NoContent();
      }
   }
}
