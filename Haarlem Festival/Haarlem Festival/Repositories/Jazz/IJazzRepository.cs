using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Haarlem_Festival.Models.Domain_Models.Jazz;

namespace Haarlem_Festival.Repositories.Jazz
{
    interface IJazzRepository
    {
        IEnumerable<JazzEvent> GetAllJazzEvents();
        IEnumerable<JazzEvent> GetJazzEventsByDate(DateTime date);
    }
}