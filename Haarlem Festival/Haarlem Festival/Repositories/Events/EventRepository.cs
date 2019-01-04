using Haarlem_Festival.Models.Database_Connection;
using Haarlem_Festival.Models.Domain_Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Repositories.Events
{
    public class EventRepository : IEventRepository
    {
        HFContext db = new HFContext();

        public Event GetEvent(int eventId)
        {
            Event e = db.Events.Find(eventId);
            return e;
        }
    }
}