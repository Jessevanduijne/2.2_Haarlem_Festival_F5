using Haarlem_Festival.Models.Domain_Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haarlem_Festival.Repositories.Tickets
{
    interface ITicketRepository
    {
        void AddTickets(List<Ticket> tickets);
        void AddOrder(Order order);
        Event GetEvent(int eventId);
    }
}
