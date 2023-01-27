using Qualminds.Pizza.Api.Models;
namespace Qualminds.Pizza.Api.Services
{
   public static class PizzaService
   {
      public static int NextId = 3;
      public static List<PizzaModel> Pizzas = new List<PizzaModel>
      {
         new PizzaModel{ Id=1, Name= "Cheese Burst Italian Pizza"},
         new PizzaModel{ Id=2, Name= "Double Cheese Burst American Pizza"},
      };
      public static List<PizzaModel> GetPizzas()
      {
         return Pizzas;
      }
      public static PizzaModel GetPizza(int id)
      {
         return Pizzas.Find(_ => _.Id == id);
      }
      public static PizzaModel CreatePizza(PizzaModel pizza)
      {
         pizza.Id = NextId;
         Pizzas.Add(pizza);
         NextId++;
         return pizza;
      }
      public static void UpdatePizza(int id, PizzaModel pizza)
      {
         if (id != pizza.Id)
         {
            throw new ArgumentException("Id passed doesn't match with Pizza's ID.", nameof(id));
         }
         var pizzaIndex = Pizzas.FindIndex(_ => _.Id == id);
         if (pizzaIndex == -1)
            throw new ArgumentOutOfRangeException("Couldn't find the pizza you were trying to update", nameof(id));
         Pizzas[pizzaIndex].Name = pizza.Name;
      }
      public static void DeletePizza(int id)
      {
         var pizza = GetPizza(id);
         if(pizza is null)
            throw new ArgumentException("Invalid pizza id", nameof(id));
         Pizzas.Remove(pizza);
      }
   }
}
