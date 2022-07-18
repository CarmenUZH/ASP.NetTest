using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASPtest.Pages.Restaurants
{
    public class MyTableModel : PageModel
    {
        public List<string> Pizzas = new List<string>();  //Important to make this get; set; so that you always get it
      
        public IActionResult OnGet() //strictly an input model
        {
            return Page();
        }
        public async Task<JsonResult> OnPost(String txt, bool chk)
        {
            await Task.Delay(500);
            Pizzas.Add(txt);

            // insert a break point to check 
            // the String txt and bool chk 
            // parameters received above 
            // your database code can be written 
            // to process these values - an ID 
            // would be required too 
            return new JsonResult("OK");

        }


    }

    }


