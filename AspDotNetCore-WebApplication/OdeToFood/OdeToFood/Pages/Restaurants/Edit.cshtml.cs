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
        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? id)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>(); //here genererate the dropdown value
            if (id.HasValue)
            {
                ViewData["Title"] = "Editing";
                Restaurant = _restaurantData.GetRestaurantById(id.Value);
            }
            else
            {
                ViewData["Title"] = "Add New Restaurant";
                Restaurant = new Restaurant();
            }
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        //Here define post method
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) //check validation error
            {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if(Restaurant.Id > 0)
            {
                Restaurant = _restaurantData.Update(Restaurant);
                TempData["Message"] = "Restaurant Updated";
            }
            else
            {
                Restaurant = _restaurantData.Add(Restaurant);
                TempData["Message"] = "New Restaurant Added";
            }
            _restaurantData.Commit();
          
            return RedirectToPage("./Details", new { id = Restaurant.Id });
        }
    }
}
