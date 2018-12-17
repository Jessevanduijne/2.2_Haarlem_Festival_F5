using Haarlem_Festival.Models.Domain_Models.Food;
using Haarlem_Festival.Models.Domain_Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haarlem_Festival.Repositories.Food
{
    interface IFoodRepository
    {
        IEnumerable<Restaurant> GetAllRestaurants();
        Restaurant GetRestaurant(int restaurantId);
        IEnumerable<FoodEvent> GetAllFoodEvents(int restaurantId);
        ICollection<Cuisine> GetAllCuisinesForRestaurant(int restuarantId);
        //FoodEvent GetFoodEvent(int restaurantId);
    }
}
