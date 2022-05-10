using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using OdeToFood.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OdeToFood.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly OdeToFoodDbContext _db;
        public RestaurantsController(OdeToFoodDbContext db)
        {
            _db = db;
        }

        // GET: api/Restaurants
        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            return _db.Restaurants;
        }

        // GET api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var restaurants = await _db.Restaurants.FindAsync(id);
            if(restaurants == null)
            {
                return NotFound();
            }
            return Ok(restaurants);
        }

        // POST api/Restaurants
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Restaurants.Add(restaurant);
            await _db.SaveChangesAsync();

            return Ok(restaurant);
        }

        // PUT api/Restaurants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != restaurant.Id)
            {
                return BadRequest();
            }

            _db.Entry(restaurant).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }

        // DELETE api/Restaurants/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
