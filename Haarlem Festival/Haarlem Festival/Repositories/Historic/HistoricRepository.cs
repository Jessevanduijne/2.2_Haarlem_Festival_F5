using Haarlem_Festival.Models.Domain_Models.Historic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Repositories.Historic
{
    public class HistoricRepository : IHistoricRepository
    {
        public IEnumerable<HistoricEvent> GenerateHistoricData()
        {
            IEnumerable<HistoricEvent> tours = new List<HistoricEvent>();

            return tours;
        }
    }
}