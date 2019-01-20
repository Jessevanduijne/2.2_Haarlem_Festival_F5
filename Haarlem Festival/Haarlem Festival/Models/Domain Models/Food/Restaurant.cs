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
        
        [Display(Name = "Restaurant Name")]
        public string RestaurantName { get; set; }

        [Display(Name = "Stars")]
        public int Stars { get; set; }
        public string ImageLink { get; set; }
        public string Address { get; set; }
        [Display(Name = "Route")]
        public string RouteLink { get; set; }

        [Display(Name = "Website")]
        public string WebsiteLink { get; set; }

        [Display(Name = "Price children")]
        public float PriceAdults { get; set; }

        [Display(Name = "Price adults")]
        public float PriceChildren { get; set; }

        // Collections
        public virtual ICollection<Cuisine> Cuisines { get; set; } // Creates extra table

        // Retrieve info from google
        public string GooglePlacesID { get; set; }

    }
}