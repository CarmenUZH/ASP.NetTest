using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IPizzaData
    {
        string Add(string newPizza);
        int Commit();
        string Delete(string id);
        List<string> GetAll();
        int GetCountOfPizzas();
        string GetPizzassByName(string name);
    }
}