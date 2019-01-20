using Haarlem_Festival.Models.Domain_Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.View_Models.Tickets
{
    public class TicketOverview
    {
        public TicketOverview(List<Ticket> Tickets, int TotalTickets, float TotalPrice)
        {
            this.Tickets = Tickets;
            this.TotalTickets = TotalTickets;
            this.TotalPrice = TotalPrice;
        }

        public List<Ticket> Tickets { get; set; }
        public int TotalTickets { get; set; }
        public float TotalPrice { get; set; }
    }
}