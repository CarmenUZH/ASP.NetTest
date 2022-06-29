using OdeToFood.Core; //Add refrence!!
using System;
using System.Collections.Generic;
using System.Text;


namespace OdeToFood.Data
{
    public interface IRestaurantData //Just the interface
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int id);
        int GetCountOfRestaurants();
        int Commit();
        
    }
}
