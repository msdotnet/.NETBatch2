using Microsoft.AspNetCore.Mvc;
using Qualminds.Pizza.Api.Models;
using Qualminds.Pizza.Api.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Qualminds.Pizza.Api.Controllers
{
   [Route("[controller]")]
   [ApiController]
   public class PizzasController : ControllerBase
   {
      [HttpGet]
      public IEnumerable<PizzaModel> Get()
      {
         return PizzaService.GetPizzas();
      }

      [HttpGet("{id}")]
      public ActionResult Get(int id)
      {
         var pizza = PizzaService.GetPizza(id);
         if (pizza == null)
         {
            return NotFound();
         }
         return Ok(pizza);
      }

      [HttpPost]
      public ActionResult Post([FromBody] PizzaModel pizza)
      {
         var newPizza = PizzaService.CreatePizza(pizza);
         return CreatedAtAction(nameof(Post), newPizza);
      }

      [HttpPut("{id}")]
      public ActionResult Put(int id, [FromBody] PizzaModel pizza)
      {
         try
         {
            PizzaService.UpdatePizza(id, pizza);
            return NoContent();
         }
         catch (ArgumentOutOfRangeException ex)
         {
            return NotFound(ex.Message);
         }
         catch (ArgumentException ex)
         {
            return BadRequest(ex.Message);
         }
      }

      [HttpDelete("{id}")]
      public ActionResult Delete(int id)
      {
            PizzaService.DeletePizza(id);
            return NoContent();
      }
   }
}
