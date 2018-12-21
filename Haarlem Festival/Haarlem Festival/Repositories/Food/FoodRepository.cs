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

        public Restaurant GetRestaurant(int restaurantId)
        {
            Restaurant restaurant = db.Restaurants.Find(restaurantId);
            return restaurant;
        }

        public IEnumerable<FoodEvent> GetAllFoodEvents(int restaurantId)
        {
            IEnumerable<FoodEvent> events = db.Events.OfType<FoodEvent>().Where(x => x.RestaurantID == restaurantId);
            return events;
        }

        public ICollection<Cuisine> GetAllCuisinesForRestaurant(int restaurantId)
        {
            ICollection<Cuisine> cuisines = db.Cuisines.Where(c => c.Restaurants.Any(r => r.RestaurantID == restaurantId)).ToList();
            return cuisines;
        }

        //public FoodEvent GetFoodEvent(int restaurantId)
        //{
        //    FoodEvent foodEvent = db.FoodEvents.Find(restaurantId);
        //    return foodEvent;
        //}
    }
}