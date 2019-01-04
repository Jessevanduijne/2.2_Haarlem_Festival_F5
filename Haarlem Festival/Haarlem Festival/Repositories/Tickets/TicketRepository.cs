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

        public void CreateTicket(Ticket ticket)
        {
            db.Tickets.Add(ticket);
            db.SaveChanges();
        }
    }
}