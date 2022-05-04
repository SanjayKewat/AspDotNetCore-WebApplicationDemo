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

        //here initializing IConfiguration interface
        public ListModel(IConfiguration configuration, IRestaurantData restaurantData)
        {
            this._config = configuration;
            RestaurantData = restaurantData;
        }

        //this method handle the get request
        public void OnGet()
        {
            //Message = "Hello, world!";
            Message = _config["Message"];//here reading value from appsettings.json file, using IConfiguration 
            Restaurants = RestaurantData.GetAllData(); // get all data from core project
        }
    }
}
