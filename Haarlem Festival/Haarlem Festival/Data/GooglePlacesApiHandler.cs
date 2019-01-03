using Haarlem_Festival.Data.Food;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Haarlem_Festival.Data
{
    public class GooglePlacesApiHandler
    {
        const string googlePlacesApiKey = "AIzaSyAerwcG1T8RWkx6dGfeyPF3xuAkUk97QOE";
        const int reviewCharLength = 80;

        public Review GetRestaurantReview(string googlePlacesId)
        {
            // Client for retrieving data from json string
            WebClient webClient = new WebClient();

            // Read data & put in object
            string rawJson = webClient.DownloadString("https://maps.googleapis.com/maps/api/place/details/json?placeid=" + googlePlacesId + "&fields=name,rating,review&key=" + googlePlacesApiKey);
            JsonRestaurantReview restaurantReview = JsonConvert.DeserializeObject<JsonRestaurantReview>(rawJson);

            // Get single review from someone who gave five stars (some positive vibes on the page)
            Review bestReview = restaurantReview.result.reviews.Where(x => x.rating == 5).FirstOrDefault();
                        
            // Adjust length of review
            if(bestReview.text.Length > reviewCharLength)
            {
                bestReview.text = bestReview.text.Substring(0, reviewCharLength) + "...";                
            }

            return bestReview;
        }
    }
}