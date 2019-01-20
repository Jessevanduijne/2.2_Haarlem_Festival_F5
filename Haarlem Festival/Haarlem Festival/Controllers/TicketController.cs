using Haarlem_Festival.Models.Domain_Models.General;
using Haarlem_Festival.Models.Input_Models.Tickets;
using Haarlem_Festival.Models.View_Models.Tickets;
using Haarlem_Festival.Repositories.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Haarlem_Festival.Controllers
{
    public class TicketController : Controller
    {
        ITicketRepository ticketRepository = new TicketRepository();

        private List<Ticket> GetSessionTickets()
        {
            return (List<Ticket>)Session["CurrentTickets"];
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Ticket> tickets = (List<Ticket>)Session["CurrentTickets"];

            if (tickets != null)
            {
                float totalPrice = tickets.Sum(t => t.Price);
                int totalTickets = tickets.Sum(t => t.Amount);

                TicketOverview viewModel = new TicketOverview(tickets, totalTickets, totalPrice);

                return View(viewModel);
            }
            else
            {
                ModelState.AddModelError("", "It seems you dont have any tickets yet..");

                // An empty viewmodel is needed, as the view needs a ticket-list to loop through
                TicketOverview emptyModel = new TicketOverview(new List<Ticket>(), 0, 0);
                return View(emptyModel);
            }
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
            List<Ticket> tickets = (List<Ticket>)Session["CurrentTickets"];
            if (tickets == null)
            {
                return RedirectToAction("Index", "Ticket");
            }

            Payment model = new Payment();
            model.PaymentMethods = new List<string>(new string[]
            {
                "Cash at the ticket counter", "iDeal", "Visa", "PayPal"
            });

            return View(model);
        }

        [HttpPost]
        public ActionResult Payment(Payment paymentModel)
        {
            paymentModel.PaymentMethods = new List<string>(new string[]
            {
                "Cash at the ticket counter", "iDeal", "Visa", "PayPal"
            });

            if (ModelState.IsValid)
            {
                List<Ticket> tickets = GetSessionTickets();
                ticketRepository.AddTickets(tickets);

                Order order = new Order();
                order.Tickets = tickets; // remove?
                order.FirstName = paymentModel.FirstName;
                order.LastName = paymentModel.LastName;
                order.Email = paymentModel.Email;
                order.IsPaid = true; // never false, because a real payment system lacks in this project
                order.PaymentMethod = paymentModel.SelectedPaymentMethod;
                order.OrderPlaced = DateTime.Now;

                ticketRepository.AddOrder(order);

                return RedirectToAction("PaymentResult", "Ticket", order);
            }
            return View(paymentModel);
        }

        [HttpGet]
        public ActionResult PaymentResult(Order order)
        {
            List<Ticket> tickets = GetSessionTickets();

            // Eventname is needed in the view
            foreach(var ticket in tickets)
            {
                ticket.Event = ticketRepository.GetEvent(ticket.EventId);
            }

            order.Tickets = tickets;

            return View(order);
        }
    }
}