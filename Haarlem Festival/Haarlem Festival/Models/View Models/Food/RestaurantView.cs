using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Haarlem_Festival.Data.Food;
using Haarlem_Festival.Models.Domain_Models.Food;

namespace Haarlem_Festival.Models.View_Models.Food
{
    public class RestaurantView
    {
        public RestaurantView(Restaurant Restaurant, Review Review)
        {
            this.Restaurant = Restaurant;
            this.Review = Review;
        }

        // Domain model [Database]:
        public Restaurant Restaurant { get; set; }

        // Google API Info [Retrieved with google places key which is stored in DB]:
        public Review Review { get; set; }
    }
}