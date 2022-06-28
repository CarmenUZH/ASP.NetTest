using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Core //New class for Restaurants
{
    public enum FoodType
    {
        None,
        Mexican,
        French,
        Garbage
    }
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

    }
}
