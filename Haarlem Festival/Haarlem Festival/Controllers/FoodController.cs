using Haarlem_Festival.Models.Domain_Models.Food;
using Haarlem_Festival.Models.Domain_Models.General;
using Haarlem_Festival.Models.View_Models;
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

            foreach(Restaurant restaurant in restaurants)
            {
                restaurant.Cuisines = foodRepository.GetAllCuisinesForRestaurant(restaurant.RestaurantID);             
            }

            return View(restaurants);
        }

        public ActionResult BookRestaurant(int restaurantId)
        {
            // Create Viewmodel
            RestaurantBooking booking = new RestaurantBooking();
            booking.Events = foodRepository.GetAllFoodEvents(restaurantId);
            booking.Restaurant = foodRepository.GetRestaurant(restaurantId);

            // Fix the datetime issue:
            TimeSpan timeAtRestaurant = booking.Events.First().EndTime.Subtract(booking.Events.First().StartTime);
            booking.TimeAvailable = String.Format("{0:00}:{1:00}", timeAtRestaurant.Hours, timeAtRestaurant.Minutes);


            return PartialView("BookEvent", booking);
        }

        [HttpPost]
        public ActionResult BookRestaurant(RestaurantBooking booking)
        {          
            Order order = new Order();
            Ticket ticket = new Ticket();

            ticket.Amount = booking.AdultTickets + booking.ChildTickets;
            ticket.EventId = booking.SelectedEvent;         

            ticket.Price = (booking.AdultTickets * booking.Restaurant.PriceAdults) +
                           (booking.ChildTickets * booking.Restaurant.PriceChildren);
            ticket.OrderId = order.OrderID; // ??
            
            order.IsPaid = false;
            order.Tickets.Add(ticket);
            Session["currentOrder"] = order;

            return RedirectToAction("Index", "TicketController");
        }
    }
}