using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData _restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this._restaurantData = restaurantData;
        }

        //ViewComponent  method declare with IViewComponentResult
        public IViewComponentResult Invoke()
        {
            var count = _restaurantData.GetCountOfRestaurant();
            //return the view in count
            return View(count);
        }
    }
}
