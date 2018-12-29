using Haarlem_Festival.Models.Domain_Models.Food;
using Haarlem_Festival.Models.View_Models;
using Haarlem_Festival.Repositories.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Haarlem_Festival.Controllers
{
    public class FoodController : Controller
    {
        IFoodRepository foodRepository = new FoodRepository();

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Restaurant> restaurants = foodRepository.GetAllRestaurants();

            foreach(Restaurant restaurant in restaurants)
            {
                restaurant.Cuisines = foodRepository.GetAllCuisinesForRestaurant(restaurant.RestaurantID);             
            }

            return View(restaurants);
        }

        public ActionResult FoodEvents(int restaurantId)
        {
            // Create Viewmodel
            RestaurantBooking booking = new RestaurantBooking();
            booking.Events = foodRepository.GetAllFoodEvents(restaurantId);
            booking.Restaurant = foodRepository.GetRestaurant(restaurantId);



            return PartialView("BookEvent", booking);
        }
    }
}