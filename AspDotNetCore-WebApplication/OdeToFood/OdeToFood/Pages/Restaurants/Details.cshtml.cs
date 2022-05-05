using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        public Restaurant Restaurant { get; set; }


        public DetailsModel(IRestaurantData restaurantData)
        {
            this._restaurantData = restaurantData;
        }
        public IActionResult OnGet(int id)
        {
            Restaurant = _restaurantData.GetRestaurantById(id);
            if(Restaurant == null)
            {
                return  RedirectToPage("./NotFound"); //RedirectTo the specific Page
            }
            return Page();//here return the html page, this used with IActionResult
        }
    }
}
