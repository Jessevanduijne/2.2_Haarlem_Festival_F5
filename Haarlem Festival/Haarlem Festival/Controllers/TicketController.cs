using Haarlem_Festival.Models.Domain_Models.General;
using Haarlem_Festival.Models.View_Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Haarlem_Festival.Controllers
{
    public class TicketController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {           
            List<Ticket> tickets = (List<Ticket>)Session["CurrentTickets"];

            if (ModelState.IsValid)
            {
                if (tickets != null)
                {
                    float totalPrice = tickets.Sum(t => t.Price);
                    int totalTickets = tickets.Sum(t => t.Amount);

                    TicketOverview viewModel = new TicketOverview(tickets, totalTickets, totalPrice);

                    return View(viewModel);
                }
                else ModelState.AddModelError("", "It seems you dont have any tickets yet..");
            }
            else ModelState.AddModelError("", "You can't pay if you don't have any tickets");

            return View(new TicketOverview(new List<Ticket>(), 0, 0));
        }

        [HttpGet]
        public ActionResult DeleteTicket(int eventId)
        {
            // EventId is passed because ticketId doesn't exist yet

            List<Ticket> tickets = (List<Ticket>)Session["currentTickets"];
            Ticket ticket = tickets.Find(x => x.EventId == eventId);
            tickets.Remove(ticket);

            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult Index(TicketOverview viewmodel)
        //{

        //}

        [HttpGet]
        public ActionResult Payment()
        {

            return View();
        }
    }
}