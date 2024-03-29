﻿using OdeToFood.Core; //Add refrence!!
using System.Collections.Generic;


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
