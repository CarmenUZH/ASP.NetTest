using OdeToFood.Core;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPtest.Tests
{
    internal class FakeData : IRestaurantData
    {

        public List<Restaurant> restaurants;

        public FakeData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1, Name="ONE",Location="Place", Food=FoodType.Garbage, Deaths=5, Animatronics=5},
                new Restaurant{Id=2, Name="TWO", Location="Ort", Food=FoodType.None, Deaths=1, Animatronics=4},
                new Restaurant{Id=3, Name="THREE", Location="Area", Food = FoodType.French, Deaths=0, Animatronics=10}
            };
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;//for testing purposes
            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);

        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
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
    }
}
