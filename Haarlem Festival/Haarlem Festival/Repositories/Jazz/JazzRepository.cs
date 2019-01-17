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
            return db.JazzEvents.Where(j => j.StartTime.Date == date.Date).ToList();
        }
    }
}