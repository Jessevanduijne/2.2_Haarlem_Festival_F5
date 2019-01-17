using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Data.Food
{
    // Auto generated class (paste special -> as Json object): DO NOT EDIT
    public class JsonRestaurantReview
    {
        public object[] html_attributions { get; set; }
        public Result result { get; set; }
        public string status { get; set; }
    }

    public class Result
    {
        public string name { get; set; }
        public float rating { get; set; }
        public Review[] reviews { get; set; }
    }

    public class Review
    {
        public string author_name { get; set; }
        public string author_url { get; set; }
        public string language { get; set; }
        public string profile_photo_url { get; set; }
        public int rating { get; set; }
        public string relative_time_description { get; set; }
        public string text { get; set; }
        public int time { get; set; }
    }
}