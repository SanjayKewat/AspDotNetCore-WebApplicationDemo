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
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetRestaurantById(int id);
        Restaurant Update(Restaurant restaurant);
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            this.restaurants = new List<Restaurant>()
            {
                new Restaurant(){Id = 1, Name ="Scott's Pizza",Location="Maryland", Cuisine = CuisineType.Italian},
                new Restaurant(){Id = 2, Name ="Mc Donals",Location="NeitherLands", Cuisine = CuisineType.Mexican},
                new Restaurant(){Id = 3, Name ="Gulati ICE Cream",Location="Rajpur Road", Cuisine = CuisineType.Indian},
                new Restaurant(){Id = 4, Name ="Chaiwali",Location="Karanpur Road", Cuisine = CuisineType.Indian}

            };
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Update(Restaurant restaurant)
        {
           var entity = restaurants.FirstOrDefault(x=>x.Id == restaurant.Id);
            if(entity != null)
            {
                entity.Name = restaurant.Name;
                entity.Location = restaurant.Location;
                entity.Cuisine = restaurant.Cuisine;
            }
            return entity; 
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
           return from r in restaurants
                  where string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name.ToLower())
                  orderby r.Name select r;
        }
    }
}
