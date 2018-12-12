using Haarlem_Festival.Models.Database_Connection;
using Haarlem_Festival.Models.Domain_Models.Food;
using Haarlem_Festival.Models.Domain_Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Repositories.Food
{
    public class FoodRepository : IFoodRepository
    {
        private HFContext db = new HFContext();

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            IEnumerable<Restaurant> restaurants = db.Restaurants;
            return restaurants;
        }

        public IEnumerable<FoodEvent> GetAllFoodEvents()
        {
            IEnumerable<FoodEvent> events = db.FoodEvents;
            return events;
        }

        public ICollection<Cuisine> GetAllCuisinesForRestaurant(int restaurantId)
        {
            ICollection<Cuisine> cuisines = db.Cuisines.Where(c => c.Restaurants.Any(r => r.RestaurantID == restaurantId)).ToList();
            return cuisines;
        }
    }
}