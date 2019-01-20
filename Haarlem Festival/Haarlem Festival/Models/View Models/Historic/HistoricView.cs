using Haarlem_Festival.Models.Domain_Models.Historic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.View_Models.Historic
{
    public class HistoricView
    {
        public HistoricView(HistoricEvent historicEvent)
        {
            this.HistoricEvent = historicEvent;
        }
        
        // Domain model [Database]:
        public HistoricEvent HistoricEvent { get; set; }
    }
}