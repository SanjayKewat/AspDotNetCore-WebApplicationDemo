using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData RestaurantData;
        private readonly ILogger<ListModel> _logger;
        private readonly IConfiguration _config;

        //passing this property in cshtml page
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        //[BindProperty] used for input output parameter
        //ByDefault this property support only httppost method
               
        [BindProperty(SupportsGet =true)] // forcely define to support httpget method
        public string SearchTerm { get; set; }

        //here initializing IConfiguration interface
        //here enabling the lpgging in list model
        public ListModel(IConfiguration configuration, IRestaurantData restaurantData,
                        ILogger<ListModel> logger)
        {
            this._config = configuration;
            RestaurantData = restaurantData;
            this._logger = logger;
        }

        //this method handle the get request
        //public void OnGet(string searchTerm) //search parameter received  from html & send the data
        public void OnGet()
        {
            _logger.LogInformation("Get request call");  //testing logger 
            //Message = "Hello, world!";
            Message = _config["Message"];//here reading value from appsettings.json file, using IConfiguration 
            Restaurants = RestaurantData.GetRestaurantByName(SearchTerm); // get all data from core project, SearchTerm property used here
            _logger.LogError("Get request call, pass response"); //testing logger 
        }
    }
}
