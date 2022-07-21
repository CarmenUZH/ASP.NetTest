using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;
using System.Collections.Generic;

namespace ASPtest.Pages.Pizza
{
    public class PizzaModel : PageModel
    {
        private readonly IPizzaData pizzaData;
        public List<string> Pizzas { get; set; } //Important to make this get; set; so that you always get it


        [BindProperty]
        public string pizza { get; set; }

        public PizzaModel(IPizzaData pizzaData) //Page uses these services to fulfill the onGet Method
        {
            this.pizzaData = pizzaData; //Don't forget to instantiate
        }
        public void OnGet()
        {
            Pizzas = pizzaData.GetAll();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) //Basically "try gain"
            {
                return Page();

            }

            pizzaData.Add(pizza);
            pizzaData.Commit(); //flush changes into datasource
            return RedirectToPage("./ShowPizzas");

        }
    }
}

