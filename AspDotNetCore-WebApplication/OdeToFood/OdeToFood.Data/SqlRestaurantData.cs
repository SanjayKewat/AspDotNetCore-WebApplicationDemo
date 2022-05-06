using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext _db;
        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            _db = db;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            _db.Add(restaurant);
            return restaurant;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetRestaurantById(id);
            if(restaurant != null)
            {
                _db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetRestaurantById(int id)
        {
            //here Find() search the data on primary key basis
            return _db.Restaurants.FirstOrDefault(x=>x.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            var query = from r in _db.Restaurants
                        where string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name.ToLower())
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            //here Attach() is used for update the entity, it directly update the value in the db, no need to first fetch the detail from DB
            var entity = _db.Restaurants.Attach(restaurant);
            entity.State = EntityState.Modified;
            return restaurant;
        }
    }
}
