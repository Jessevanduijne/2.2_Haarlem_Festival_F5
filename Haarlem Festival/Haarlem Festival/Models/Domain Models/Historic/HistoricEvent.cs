using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Haarlem_Festival.Models.Domain_Models.General;
using System.ComponentModel.DataAnnotations;

namespace Haarlem_Festival.Models.Domain_Models.Historic
{
    [Table("HistoricEvents")]
    public class HistoricEvent : Event
    {
        [ForeignKey("Guide")]
        public int GuideID { get; set; }
        public virtual Guide Guide { get; set; }

        [NotMapped]
        public string TicketAvailable => (CurrentTickets == 0 ?
                   "<img src='/Content/Historic/img/cartcross.png'style='width:25px' />" :
                    "<img src='/Content/Historic/img/addcart.png' class='add-cart' />");

        [NotMapped]
        public DayOfWeek Day { get { return ((DayOfWeek)(StartTime.DayOfWeek)); } }

        [NotMapped]
        public int Hour { get { return (StartTime.Hour); } }

        [NotMapped]
        public int Minutes { get { return (StartTime.Minute); } }


        [NotMapped]
        public string GetGeneratedHtml => (GenerateHtml());

        private string GenerateHtml()
        {
            string tableRowOpening = "<tr class='dayOfWeek "+Day.ToString().ToLower()+"'>";
            string tableRowClosing = "</tr>";
            string prijsStr = "<td>17,50</td>";
            string timeStr = "<td>" + Hour.ToString() + ":" + Minutes.ToString("00") + "</td>";
            string tourStr = "<td id='"+EventId+"'>" + TicketAvailable + "</td>";

            string htmlGenerated = "";

            if ((EventId % 3) == 1)
            {
                htmlGenerated += tableRowOpening + timeStr + prijsStr;
                htmlGenerated += tourStr;
            }
            else if ((EventId % 3) == 2)
            {
                htmlGenerated += tourStr;
            }
            else if ((EventId % 3) == 0)
            {
                htmlGenerated += tourStr;
                htmlGenerated += tableRowClosing;
            }
            else
            {
                htmlGenerated += "";
            }

            return htmlGenerated;
        }
    }
}