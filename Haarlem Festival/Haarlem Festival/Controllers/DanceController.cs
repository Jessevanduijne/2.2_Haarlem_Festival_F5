using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Haarlem_Festival.Repositories.Dance;
using Haarlem_Festival.Models.Domain_Models.Dance;
using Haarlem_Festival.Models.View_Models.Dance;
using Haarlem_Festival.Models.Domain_Models.General;
using Haarlem_Festival.Repositories.Events;

namespace Haarlem_Festival.Controllers
{
    public class DanceController : Controller
    {
        readonly IDanceRepository repo = new DanceRepository();
        readonly IEventRepository eventRepo = new EventRepository();
        IEnumerable<DanceEvent> DanceEvents;
        IEnumerable<Artist> Artist;
        ArtistView a = new ArtistView();
        IList<ArtistView> Artistlist;
        Ticketview Tickets = new Ticketview();        
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DanceTickets()
        {
            // get dance events
            DanceEvents = repo.GetAllDanceEvents();
            Tickets = Tickets.DomainToView(DanceEvents);
            return PartialView(Tickets);
        }
        public ActionResult Artists()
        {
            // get artists
            Artist = repo.GetAllArtists();
            Artistlist = a.DomainToView(Artist);
            return PartialView(Artistlist);
        }

        [HttpPost]
        public ActionResult AddTickets()
        {
            int EventId = int.Parse(Request.Form["EventId"]);
            int Amount = int.Parse(Request.Form["TicketAmount"]);

            DanceEvent e = repo.GetDanceEvent(EventId);

            List<Ticket> tickets = new List<Ticket>();
            Ticket ticket = new Ticket();

            ticket.Amount = Amount;
            ticket.EventId = e.EventId;
            ticket.Event = eventRepo.GetEvent(e.EventId);
            ticket.Price = e.Price*Amount;
            ticket.SpecialRequest = null;

            if(ticket.Amount > (ticket.Event.MaxTickets - ticket.Event.CurrentTickets))
            {
                return RedirectToAction("NoTickets", "Dance");
            }
            else
            {
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
        
        public ActionResult NoTickets()
        {
            return View();
        }
    }
}