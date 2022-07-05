using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public class InMemoryPizzaData : IPizzaData
    {
        public List<string> pizzas;

        public InMemoryPizzaData()
        {
            pizzas = new List<string>()
            {
                "garbage"
            };
        }

        public string Add(string newPizza)
        {
            pizzas.Add(newPizza);
            return newPizza;
        }

        public int Commit() //Doesnt mean anything until now
        {
            return 0;
        }

        public List<string> GetAll()
        {
            return pizzas;
        }
        public string GetPizzassByName(string name)
        {
            if (pizzas.Contains(name))
            {
                return name;
            }
            else
            {
                return null;
            }
        }

        public string Delete(string id)
        {
            var pizza = GetPizzassByName(id);
            if (pizza != null)
            {
                pizzas.Remove(pizza);
            }
            return pizza;
        }

        public int GetCountOfPizzas()
        {
            return pizzas.Count();
        }
    }
}

