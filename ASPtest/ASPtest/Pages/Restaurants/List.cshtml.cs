using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ASPtest.Pages.Restaurants
{
    public class ListModel : PageModel //Use pagemodel to inject services that will give me access to data and then use it in List.cshtml
    {
        private readonly IConfiguration config;

        public string Message { get; set; }
        public string NewMessage { get; set; }
        public ListModel(IConfiguration config)
        {
            this.config = config;
        }

        public void OnGet()
        {
            Message = "My Restaurant";
            NewMessage = config["Message"];
        }
        //Page Model is responsible for fetching information
    }
}
