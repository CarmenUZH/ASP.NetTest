using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace ASPtest.Pages.Restaurants
{
    public class MyTableModel : PageModel
    {
      

            public async Task<JsonResult> OnPost(String txt, bool chk)
            {

                await Task.Delay(500);

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


