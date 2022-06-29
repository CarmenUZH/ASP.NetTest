using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OdeToFood.Core //New class for Restaurants
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Did you straight up just.. Forget the name of the place?"), StringLength(50, MinimumLength = 4, ErrorMessage = "Wouldn't it be fun if you chose... ya know... a GOOD name?")]
        public string Name { get;  set; }
        [StringLength(280)]
        public string Location { get; set; }
        public FoodType Food { get; set; }
        [Required(ErrorMessage = "As fun as this may be, i dont believe you when you tell me that NOONE died here"), Range(0.00, 100.00, ErrorMessage = "Come on dude, Please don't murder the entire restaurant")]
        public int Deaths { get; set; }
        public int Animatronics { get; set; }
    }
}
