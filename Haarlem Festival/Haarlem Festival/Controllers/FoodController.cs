using Haarlem_Festival.Models.Domain_Models.Food;
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
            return View(restaurants);
        }
    }
}