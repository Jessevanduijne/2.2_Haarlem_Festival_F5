using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Haarlem_Festival.Models.Domain_Models;
using Haarlem_Festival.Models.Domain_Models.Historic;

namespace Haarlem_Festival.Repositories.Historic
{
    interface IHistoricRepository
    {
        IEnumerable<HistoricEvent> GetAllTours();
        HistoricEvent GetTour(int eventID);

    }
}