using Haarlem_Festival.Models.Domain_Models.Food;
using Haarlem_Festival.Models.Domain_Models.General;
using Haarlem_Festival.Models.View_Models.Food;
using Haarlem_Festival.Repositories.Events;
using Haarlem_Festival.Repositories.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Haarlem_Festival.Controllers
{
    public class FoodController : Controller
    {
        IFoodRepository foodRepository = new FoodRepository();
        IEventRepository eventRepository = new EventRepository();

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Restaurant> restaurants = foodRepository.GetAllRestaurants();

            foreach (Restaurant restaurant in restaurants)
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
            booking.RestaurantName = foodRepository.GetRestaurant(restaurantId).RestaurantName;

            // Fix the datetime issue:
            TimeSpan timeAtRestaurant = booking.Events.First().EndTime.Subtract(booking.Events.First().StartTime);
            booking.TimeAvailable = String.Format("{0:00}:{1:00}", timeAtRestaurant.Hours, timeAtRestaurant.Minutes);

            // Pass ID value of restaurant: 
            booking.RestaurantId = restaurantId;

            return PartialView("BookEvent", booking);
        }

        [HttpPost]
        public ActionResult BookRestaurant(RestaurantBooking booking)
        {
            // The 'booking'-parameter is filled up only with data that is being entered in the form: ticketamount (child/adult), selected event, special request & hidden restaurantID-field
            // Only a field can be passed hidden, not an entire object. That's why we pass only the restaurantId to the viewmodel

            List<Ticket> tickets = new List<Ticket>();
            Ticket ticket = new Ticket();
            Restaurant restaurant = foodRepository.GetRestaurant(booking.RestaurantId);

            ticket.Amount = booking.AdultTickets + booking.ChildTickets;
            ticket.EventId = booking.SelectedEvent;
            ticket.Event = eventRepository.GetEvent(ticket.EventId);
            ticket.Price = (booking.AdultTickets * restaurant.PriceAdults) + (booking.ChildTickets * restaurant.PriceChildren);            

            // Create session if it doesn't exist or add ticket to existing session
            if (Session["currentTickets"] == null)
            {
                tickets.Add(ticket);
                Session["CurrentTickets"] = tickets;
            }
            else
            {
                List<Ticket> sessionTickets = (List<Ticket>)Session["currentTickets"];
                sessionTickets.Add(ticket);
            }

            return RedirectToAction("Index", "Ticket");
        }
    }
}