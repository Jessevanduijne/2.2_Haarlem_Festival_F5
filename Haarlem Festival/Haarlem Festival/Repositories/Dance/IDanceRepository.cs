using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haarlem_Festival.Models.Domain_Models.Dance;

namespace Haarlem_Festival.Repositories.Dance
{
    interface IDanceRepository
    {
        IEnumerable<DanceEvent> GetAllDanceEvents();
        IEnumerable<Artist> GetAllArtists();
        DanceEvent GetDanceEvent(int id);
    }
}
