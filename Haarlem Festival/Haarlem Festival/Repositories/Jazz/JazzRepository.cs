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
            IEnumerable<JazzEvent> jazzEvents = db.JazzEvents.Include(j => j.JazzVenue).ToList();

            return jazzEvents;
        }

        public IEnumerable<JazzEvent> GetJazzEventsByDate(DateTime date)
        {
            IEnumerable<JazzEvent> jazzEvents = GetAllJazzEvents();

            List<JazzEvent> thursday = new List<JazzEvent>();
            List<JazzEvent> friday = new List<JazzEvent>();
            List<JazzEvent> saturday = new List<JazzEvent>();
            List<JazzEvent> sunday = new List<JazzEvent>();

            foreach (JazzEvent jEvent in jazzEvents)
            {
                if (jEvent.StartTime.Date == new DateTime(2019, 7, 26))
                {
                    thursday.Add(jEvent);
                }
                else if (jEvent.StartTime.Date == new DateTime(2019, 7, 27))
                {
                    friday.Add(jEvent);
                }
                else if (jEvent.StartTime.Date == new DateTime(2019, 7, 28))
                {
                    saturday.Add(jEvent);
                }
                else if (jEvent.StartTime.Date == new DateTime(2019, 7, 29))
                {
                    sunday.Add(jEvent);
                }
            }

            return null;
        }
    }
}