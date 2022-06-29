using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace ASPtest.Pages.Restaurants
{
    public class CreateModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty] //Make Restaurant be Post-usable
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        //Page uses these services to fulfill the onGet Method
        public CreateModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper) //Get Html Helper here
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet()
        {
            Restaurant = new Restaurant();
            Restaurant.Location = "Somewhere";
            Restaurant.Food = FoodType.None;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) //Basically "try gain"
            {
                Cuisines = htmlHelper.GetEnumSelectList<FoodType>();
                return Page();
               
            }
          
            restaurantData.Add(Restaurant);
            restaurantData.Commit(); //flush changes into datasource
            TempData["Message"] = "Restaurant saved!";
            return RedirectToPage("./Details", new { restaurantId = Restaurant.Id});

        }
    }
}
