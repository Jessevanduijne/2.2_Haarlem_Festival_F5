using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.Domain_Models.Food
{
    public class Restaurant
    {
        [Key]
        public int RestaurantID { get; set; }
        
        public string RestaurantName { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public string Address { get; set; }
        public string RouteLink { get; set; }
        public string WebsiteLink { get; set; }

        public float PriceAdults { get; set; }
        public float PriceChildren { get; set; }

        // Collections
        public virtual ICollection<Cuisine> Cuisines { get; set; } // Creates extra table

        // Optional
        public string GoogleReviewLink { get; set; }

    }
}