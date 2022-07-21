using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;
//The Goal for a page model class is to respond to an http request (like GET) that will envoke the OnGet() Method
namespace ASPtest.Pages.Restaurants
{
    public class ListModel : PageModel //Use pagemodel to inject services that will give me access to data and then use it in List.cshtml
    {
        //private readonly IConfiguration config;


        public string Message { get; set; } //Information that the View is going to "consume" (public)
        public string NewMessage { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        private readonly IRestaurantData restaurantData;
       // private readonly ILogger<ListModel> logger;

        public ListModel( IRestaurantData restaurantData) //Page uses these services to fulfill the onGet Method
        {
            //this.config = config;
            this.restaurantData = restaurantData; //Don't forget to instantiate
            //this.logger = logger;
        }

        public void OnGet()//Move information from request into a model binder
        {
            //logger.LogError("Hello from ListModel");
            //Message = "My Restaurant";
            //NewMessage = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
        //Page Model is responsible for fetching information

   
    }
}
