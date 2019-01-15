using Haarlem_Festival.Models.Domain_Models.Historic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Haarlem_Festival.Models.Database_Connection;

namespace Haarlem_Festival.Repositories.Historic
{
    public class HistoricRepository : IHistoricRepository
    {
        public IEnumerable<HistoricEvent> GetAllTours()
        {
            IEnumerable<HistoricEvent> tours;
            using (HFContext db = new HFContext())
            {
                tours = db.HistoricEvents.OrderBy(x => x.EventId);
            }
            return tours;
        }

        public HistoricEvent GetTour(int eventID)
        {
            HistoricEvent tour;
            using (HFContext db = new HFContext())
            {
                tour = db.HistoricEvents.Where(tr => tr.EventId == eventID).FirstOrDefault();
            }
            return tour;
        }
    }
}