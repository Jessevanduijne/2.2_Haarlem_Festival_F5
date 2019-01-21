using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.View_Models.Food
{
    public class BookingResult
    {
        public BookingResult(string RestaurantName, DateTime StartTime, DateTime EndTime, string SpecialRequests)
        {
            this.RestaurantName = RestaurantName;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.SpecialRequests = SpecialRequests;
        }

        public BookingResult()
        {

        }

        [Display(Name = "Restaurant Name")]
        public string RestaurantName { get; set; }
        public string SpecialRequests { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}