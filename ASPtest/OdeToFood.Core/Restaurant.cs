using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Core //New class for Restaurants
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public FoodType Food { get; set; }
        public int Deaths { get; set; }
        public int Animatronics { get; set; }


    }
}
