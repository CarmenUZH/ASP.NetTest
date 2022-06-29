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
        Restaurant Update(Restaurant updatedRestaurant);
        int Commit();
        
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

        public Restaurant Update(Restaurant updatedRestaurant) //Only include the values you ACTUALLY want to change
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Food = updatedRestaurant.Food;
                restaurant.Deaths = updatedRestaurant.Deaths;
            }
            return restaurant;
        }

        public int Commit() //Doesnt mean anything until now
        {
            return 0;
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
