using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;

namespace ASPtest.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        public Restaurant MyRestaurant { get; set; }
        public void OnGet(int restaurantId) //strictly an input model
        {
            MyRestaurant = new Restaurant();
            MyRestaurant.Id = restaurantId;
        }
    }
}
