using System.Linq; //Important for the Orderby
using OdeToFood.Core; //Add refrence!!
using System;
using System.Collections.Generic;
using System.Text;


namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        
    }
    public class InMemoryRestaurantData : IRestaurantData
    {
        public List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1, Name="Freddies",Location="America", Food=FoodType.Garbage, Deaths=5, Animatronics=5},
                new Restaurant{Id=2, Name="Circus Baby", Location="Under my house", Food=FoodType.None, Deaths=1, Animatronics=4},
                new Restaurant{Id=3, Name="Pizzaplex", Location="Over my house", Food = FoodType.French, Deaths=0, Animatronics=10}
            };
        }
        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name)||r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
