using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Haarlem_Festival.Models.Database_Connection;
using Haarlem_Festival.Models.Domain_Models.Dance;
using Haarlem_Festival.Models.Domain_Models.General;


namespace Haarlem_Festival.Repositories.Dance
{
    public class DanceRepository : IDanceRepository
    {
        private HFContext db = new HFContext();

        public IEnumerable<DanceEvent> GetAllDanceEvents()
        {
            IEnumerable<DanceEvent> danceEvents;
            using (db)
            {
                danceEvents = db.Events
                                .OfType<DanceEvent>()                               
                                .ToList();
                foreach(DanceEvent d in danceEvents)
                {
                    d.DanceVenue = db.Venues.Where(b => b.VenueId == d.DanceVenueId).SingleOrDefault();
                }
            }            
            return danceEvents;
        }
        public IEnumerable<Artist> GetAllArtists()
        {
            IEnumerable<Artist> Artists = db.Artists;
            return Artists;
        }

        public DanceEvent GetDanceEvent(int ID)
        {
            DanceEvent d = (DanceEvent)db.Events.Where(b => b.EventId== ID).OfType<DanceEvent>().FirstOrDefault();
            return d;
        }

    }
}