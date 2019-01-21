using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Haarlem_Festival.Models.Domain_Models.Jazz;
using Haarlem_Festival.Models.Domain_Models.General;
using Haarlem_Festival.Models.Database_Connection;

namespace Haarlem_Festival.Repositories.Jazz
{
    public class JazzRepository : IJazzRepository
    {
        HFContext db = new HFContext();

        public IEnumerable<JazzEvent> GetAllJazzEvents()
        {
            IEnumerable<JazzEvent> jazzEvents = db.Events.OfType<JazzEvent>().Include(j => j.JazzVenue).ToList();

            return jazzEvents;
        }

        internal JazzEvent GetJazzEvent(int eventId)
        {
            return (db.JazzEvents.Find(eventId));
        }

        public IEnumerable<JazzEvent> GetJazzEventsByDate(DateTime date)
        {
            var jEvents = db.JazzEvents
                    .Where(x => x.StartTime.Year == date.Year
                            && x.StartTime.Month == date.Month
                            && x.StartTime.Day == date.Day).Include(j => j.JazzVenue);

            return jEvents;
        }
    }
}