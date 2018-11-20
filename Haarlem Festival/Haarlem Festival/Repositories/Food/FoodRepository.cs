using Haarlem_Festival.Models.Database_Connection;
using Haarlem_Festival.Models.Domain_Models.Food;
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
    }
}