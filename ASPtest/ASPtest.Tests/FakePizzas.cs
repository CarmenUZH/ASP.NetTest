using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPtest.Tests
{
    internal class FakePizzas : IPizzaData
    {
        public List<string> pizzas;

        public FakePizzas()
        {
            pizzas = new List<string>()
            {
                "one", "two", "three"
            };
        }
        public string Add(string newPizza)
        {
            pizzas.Add(newPizza);
            return newPizza;
        }

        public int Commit()
        {
            return 0;
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

        public List<string> GetAll()
        {
            return pizzas;
        }

        public int GetCountOfPizzas()
        {
            return pizzas.Count;
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
    }
}