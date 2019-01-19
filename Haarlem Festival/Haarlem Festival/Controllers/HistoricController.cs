using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Haarlem_Festival.Models.Database_Connection;
using Haarlem_Festival.Repositories.Historic;
using Haarlem_Festival.Repositories.Tickets;
using Haarlem_Festival.Repositories.Events;
using Haarlem_Festival.Models.View_Models.Historic;
using Haarlem_Festival.Models.Domain_Models.Historic;
using Haarlem_Festival.Models.Domain_Models.General;

namespace Haarlem_Festival.Controllers
{
    public class HistoricController : Controller
    {
        private IHistoricRepository historicRepository = new HistoricRepository();
        private ITicketRepository ticketRepository = new TicketRepository();
        private IEventRepository eventRepository = new EventRepository();

        // GET: Historic
        public ActionResult Index()
        {
            IEnumerable<HistoricEvent> histEvents = historicRepository.GetAllTours();

            List<HistoricView> historicEvents = new List<HistoricView>();

            foreach (HistoricEvent ev in histEvents)
            {
                ev.StartingPoint = histEvents.First().EventId;
                historicEvents.Add(new HistoricView(ev));
            }

            return View(historicEvents);
        }

        [HttpGet]
        public ActionResult BookTour(int? eventId)
        {
            if (eventId != null){
                //Create Viewmodel
                TourBooking booking = new TourBooking();
                booking.Events = historicRepository.GetAllTours();
                booking.TourName = historicRepository.GetTour((int)eventId).EventName;

                //Pass ID value of restaurant:
                booking.EventId = (int)eventId;

                return PartialView("BookTour", booking);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }



        [HttpPost]
        public ActionResult BookTour(TourBooking booking)
        {
            // The 'booking'-parameter is filled up only with data that is being entered in the form: ticketamount (child/adult), selected event, special request & hidden restaurantID-field
            // Only a field can be passed hidden, not an entire object. That's why we pass only the restaurantId to the viewmodel

            HistoricEvent historicEvent = historicRepository.GetTour(booking.EventId);

            if (ModelState.IsValid)
            {
                List<Ticket> tickets = new List<Ticket>();
                Ticket ticket = new Ticket();

                ticket.Amount = booking.RegularTickets;
                ticket.EventId = booking.EventId;
                ticket.Event = eventRepository.GetEvent(ticket.EventId);
                ticket.Price = (booking.RegularTickets * historicEvent.Price);

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
            
            // Post booking
            return PartialView("BookTour", booking);
        }
    }
}
