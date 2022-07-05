using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Data;
using System.Collections.Generic;

namespace ASPtest.Pages.Restaurants
{
    public class PizzaModel : PageModel
    {
        private readonly IPizzaData pizzaData;
        private readonly ILogger<ListModel> logger;
        private readonly IConfiguration config;

        private readonly IHtmlHelper htmlHelper;
       
        [BindProperty]
        public string pizza { get; set; }

        public PizzaModel(IConfiguration config, IPizzaData pizzaData, ILogger<ListModel> logger) //Page uses these services to fulfill the onGet Method
        {
            this.config = config;
            this.pizzaData = pizzaData; //Don't forget to instantiate
            this.logger = logger;
        }
        public void OnGet()
        {
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

