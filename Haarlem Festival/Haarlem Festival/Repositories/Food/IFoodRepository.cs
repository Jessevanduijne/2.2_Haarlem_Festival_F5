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
        IEnumerable<FoodEvent> GetAllFoodEvents();
    }
}
