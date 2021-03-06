using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace ASPtest.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty] //Make Restaurant be Post-usable
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        //Page uses these services to fulfill the onGet Method
        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper) //Get Html Helper here
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int restaurantId)
        {
            //HTML not available in page model by default, get IHtmlHelper
            Cuisines = htmlHelper.GetEnumSelectList<FoodType>();
            Restaurant = restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./Notfound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            // var attval = ModelState["Deaths"].AttemptedValue; //Model State saves all the information about what the user tried to input
            if (ModelState.IsValid)
            {
                //Model validation to check for valid input in Restaurant.cs (can be done with if else statements too)

                Restaurant = restaurantData.Update(Restaurant);
                restaurantData.Commit();
                return RedirectToPage("./Details", new { restaurantId = Restaurant.Id });
            }
            Cuisines = htmlHelper.GetEnumSelectList<FoodType>();
            return Page();

        }
    }
}
