using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Haarlem_Festival.Models.Database_Connection;
using Haarlem_Festival.Models.Domain_Models.Dance;


namespace Haarlem_Festival.Repositories.Dance
{
    public class DanceRepository : IDanceRepository
    {
        private HFContext db = new HFContext();

        public IEnumerable<DanceEvent> GetAllDanceEvents()
        {
            IEnumerable<DanceEvent> DanceEvents = db.Events.OfType<DanceEvent>();
            return DanceEvents;
        }
        public IEnumerable<Artist> GetAllArtists()
        {
            IEnumerable<Artist> Artists = db.Artists;
            return Artists;
        }

    }
}