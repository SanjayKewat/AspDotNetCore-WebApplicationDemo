using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public EditModel(IRestaurantData restaurantData,IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int id)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>(); //here genererate the dropdown value
            Restaurant = _restaurantData.GetRestaurantById(id);
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        //Here define post method
        public IActionResult OnPost()
        {
            Restaurant = _restaurantData.Update(Restaurant);
            _restaurantData.Commit();
            return Page();
        }
    }
}
