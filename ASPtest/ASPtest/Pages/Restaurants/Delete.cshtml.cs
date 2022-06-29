using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace ASPtest.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public Restaurant restaurant { get; set; }
        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IRestaurantData RestaurantData { get; }

        public IActionResult OnGet(int restaurantId)
        {
            restaurant = restaurantData.GetById(restaurantId);
            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId) //Action result so user is not "sitting on" a post request
        {
            var restaurant = restaurantData.Delete(restaurantId);
            restaurantData.Commit();

            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["DeletedMessage"] = $"{restaurant.Name} was deleted! :D";
            return RedirectToPage("./List");
        }
    }
}
