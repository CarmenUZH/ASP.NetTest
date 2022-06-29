using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OdeToFood.Core //New class for Restaurants
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required, StringLength(80) ]
        public string Name { get; set; }
        [Required, StringLength(280)]
        public string Location { get; set; }
        public FoodType Food { get; set; }
        [Range(0,100) ]
        public int Deaths { get; set; }
        [Required, Range(0, 100)]
        public int Animatronics { get; set; }
    }
}
