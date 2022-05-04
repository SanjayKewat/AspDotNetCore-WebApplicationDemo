using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllData();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            this.restaurants = new List<Restaurant>()
            {
                new Restaurant(){Id = 1, Name ="Scott's Pizza",Location="Maryland", Cuisine = CuisineType.Italian},
                new Restaurant(){Id = 1, Name ="Mc Donals",Location="NeitherLands", Cuisine = CuisineType.Mexican},
                new Restaurant(){Id = 1, Name ="Gulati ICE Cream",Location="Rajpur Road", Cuisine = CuisineType.Indian}

            };
        }
        public IEnumerable<Restaurant> GetAllData()
        {
           return from r in restaurants orderby r.Name select r;
        }
    }
}
