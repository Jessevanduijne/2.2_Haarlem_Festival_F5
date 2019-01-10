using Haarlem_Festival.Models.Domain_Models.General;
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
            if (tickets != null)
            {
                return View(tickets);
            }
            else return View(new List<Ticket>());            
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

        [HttpGet]
        public ActionResult Payment()
        {


            return View();
        }
    }
}