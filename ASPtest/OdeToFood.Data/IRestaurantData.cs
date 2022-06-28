using OdeToFood.Core; //Add refrence!!
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        
    }
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1, Name="Freddies",Location="America", Food=FoodType.Garbage},
                new Restaurant{Id=2, Name="Circus Baby", Location="Under my house", Food=FoodType.None},
                new Restaurant{Id=3, Name="Pizzaplex", Location="Over my house", Food = FoodType.French}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
