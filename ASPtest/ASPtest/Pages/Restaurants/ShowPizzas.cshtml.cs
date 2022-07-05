using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;
using System.Collections.Generic;

namespace ASPtest.Pages.Restaurants
{
    public class ShowPizzasModel : PageModel
    {

        public List<string> Pizzas { get; set; } //Important to make this get; set; so that you always get it
        private readonly IPizzaData pizzaData;
        public ShowPizzasModel(IPizzaData pizzaData)
        {
            this.pizzaData = pizzaData;
        }
        public IActionResult OnGet() //strictly an input model
        {
            Pizzas = pizzaData.GetAll();
            return Page();
        }
    }
}
