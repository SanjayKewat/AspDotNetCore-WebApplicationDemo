using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData RestaurantData;
        private readonly IConfiguration _config;

        //passing this property in cshtml page
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        //[BindProperty] used for input output parameter
        //ByDefault this property support only httppost method
               
        [BindProperty(SupportsGet =true)] // forcely define to support httpget method
        public string SearchTerm { get; set; }

        //here initializing IConfiguration interface
        public ListModel(IConfiguration configuration, IRestaurantData restaurantData)
        {
            this._config = configuration;
            RestaurantData = restaurantData;
        }

        //this method handle the get request
        //public void OnGet(string searchTerm) //search parameter received  from html & send the data
        public void OnGet()
        {
            //Message = "Hello, world!";
            Message = _config["Message"];//here reading value from appsettings.json file, using IConfiguration 
            Restaurants = RestaurantData.GetRestaurantByName(SearchTerm); // get all data from core project, SearchTerm property used here
        }
    }
}
