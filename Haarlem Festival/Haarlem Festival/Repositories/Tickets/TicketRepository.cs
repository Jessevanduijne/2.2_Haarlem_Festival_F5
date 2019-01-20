using Haarlem_Festival.Models.Database_Connection;
using Haarlem_Festival.Models.Domain_Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Repositories.Tickets
{
    public class TicketRepository : ITicketRepository
    {
        HFContext db = new HFContext();

        public void AddTickets(List<Ticket> tickets)
        {
            foreach(var ticket in tickets)
            {
                ticket.Event = null;
                db.Tickets.Add(ticket);
            }
            db.SaveChanges();
        }

        public void AddOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public Event GetEvent(int eventId)
        {
            Event e = db.Events.Find(eventId);
            return e;
        }
    }
}