using Haarlem_Festival.Models.Domain_Models.Food;
using Haarlem_Festival.Models.Domain_Models.General;
using Haarlem_Festival.Models.View_Models.Food;
using Haarlem_Festival.Repositories.Events;
using Haarlem_Festival.Repositories.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Net;
using Haarlem_Festival.Data;
using Haarlem_Festival.Data.Food;
using System.Web.Helpers;

namespace Haarlem_Festival.Controllers
{
    public class FoodController : Controller
    {
        IFoodRepository foodRepository = new FoodRepository();
        IEventRepository eventRepository = new EventRepository();
        GooglePlacesApiHandler googlePlacesApiHandler = new GooglePlacesApiHandler();

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Restaurant> restaurants = foodRepository.GetAllRestaurants();
            List<RestaurantView> restaurantViews = new List<RestaurantView>();

            foreach (Restaurant restaurant in restaurants)
            {
                // Add cuisines to restaurant
                restaurant.Cuisines = foodRepository.GetAllCuisinesForRestaurant(restaurant.RestaurantID);

                // Fill list of viewmodels (reviews aren't stored in db so vm's are necessary)
                Review review = googlePlacesApiHandler.GetRestaurantReview(restaurant.GooglePlacesID);
                restaurantViews.Add(new RestaurantView(restaurant, review));
            }
            return View(restaurantViews);
        }

        [HttpGet, NoDirectAccess]
        public ActionResult BookRestaurant(int restaurantId)
        {
            // Create Viewmodel
            RestaurantBooking booking = new RestaurantBooking();
            booking.Events = foodRepository.GetAllFoodEvents(restaurantId);

            Restaurant restaurant = foodRepository.GetRestaurant(restaurantId);
            booking.RestaurantName = restaurant.RestaurantName;
            booking.ChildrenPrice = restaurant.PriceChildren;
            booking.AdultPrice = restaurant.PriceAdults;

            // Get the correct timespan:
            TimeSpan timeAtRestaurant = booking.Events.First().EndTime.Subtract(booking.Events.First().StartTime);
            booking.TimeAvailable = String.Format("{0:00}:{1:00}", timeAtRestaurant.Hours, timeAtRestaurant.Minutes);

            // Pass ID value of restaurant: 
            booking.RestaurantId = restaurantId;

            return PartialView("BookEvent", booking);
        }

        [HttpPost, NoDirectAccess]
        public ActionResult BookRestaurant(RestaurantBooking booking)
        {
            // RestaurantName & ID are passed hidden

            Restaurant restaurant = foodRepository.GetRestaurant(booking.RestaurantId);
            Event selectedevent = eventRepository.GetEvent(booking.SelectedEvent);

            if (ModelState.IsValid)
            {
                if (selectedevent.CurrentTickets != 0 &&
                    (booking.AdultTickets + booking.ChildTickets) <= selectedevent.CurrentTickets)
                {
                    Ticket ticket = new Ticket();
                    ticket.Amount = booking.AdultTickets + booking.ChildTickets;
                    ticket.EventId = booking.SelectedEvent;
                    ticket.Event = eventRepository.GetEvent(ticket.EventId);
                    ticket.Price = (booking.AdultTickets * restaurant.PriceAdults) + (booking.ChildTickets * restaurant.PriceChildren);
                    ticket.SpecialRequest = booking.SpecialRequest;

                    // Create session if it doesn't exist or add ticket to existing session
                    if (Session["currentTickets"] == null)
                    {
                        List<Ticket> tickets = new List<Ticket>();
                        tickets.Add(ticket);
                        Session["CurrentTickets"] = tickets;
                    }
                    else
                    {
                        List<Ticket> sessionTickets = (List<Ticket>)Session["currentTickets"];
                        sessionTickets.Add(ticket);
                    }
                    BookingResult resultViewModel = new BookingResult(booking.RestaurantName, ticket.Event.StartTime, ticket.Event.EndTime, ticket.SpecialRequest);
                    return RedirectToAction("BookEventSuccess", resultViewModel);
                }
                ModelState.AddModelError("", "There are only " + selectedevent.CurrentTickets + " tickets available");
            }

            // Validation failed, reload some data:
            booking.Events = foodRepository.GetAllFoodEvents(restaurant.RestaurantID);
            return PartialView("BookEvent", booking);
        }

        [NoDirectAccess]
        public ActionResult BookEventSuccess(BookingResult resultViewModel)
        {
            if (resultViewModel.SpecialRequests != null)
            {
                ViewBag.SpecialRequestLabel = "Special Request: ";
            }

            return PartialView("BookEventSuccess", resultViewModel);
        }
    }
}