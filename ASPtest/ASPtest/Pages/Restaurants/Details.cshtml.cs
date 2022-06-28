using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace ASPtest.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        public Restaurant MyRestaurant { get; set; }
        private readonly IRestaurantData restaurantData;
        public DetailsModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId) //strictly an input model
        {
            MyRestaurant = restaurantData.GetById(restaurantId);
            if (MyRestaurant == null) //For nonsense Id's
            {
                return RedirectToPage("./Notfound");
            }
            return Page();
        }
    }
}
