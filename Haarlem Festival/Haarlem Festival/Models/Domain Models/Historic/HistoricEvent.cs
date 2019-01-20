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
        public float Price = 17.50f;

        [NotMapped]
        public int FamilyPrice = 60;

        [NotMapped]
        public string TicketAvailable => (CurrentTickets == 0 ?
                   "<img src='/Content/Historic/img/cartcross.png'style='width:25px' />" :
                    ActionButtonStart + "<img src='/Content/Historic/img/addcart.png' class='add-cart' />") + ActionButtonEnd;

        [NotMapped]
        public DayOfWeek Day { get { return ((DayOfWeek)(StartTime.DayOfWeek)); } set { } }

        [NotMapped]
        public int Hour { get { return (StartTime.Hour); } }

        [NotMapped]
        public int Minutes { get { return (StartTime.Minute); } }

        [NotMapped]
        public int StartingPoint { get; set; }

        [NotMapped]
        public string ActionButtonStart { get { return "<button id='loadEvents' data-toggle='modal' data-target='#MyModal' onclick='BookTour("+EventId+")'>"; } }

        [NotMapped]
        public string ActionButtonEnd { get { return "</button>"; } }

        [NotMapped]
        public string GetGeneratedHtml => (GenerateHtmlTable());

        private string GenerateHtmlTable()
        {
            string tableRowOpening = "<tr class='dayOfWeek "+Day.ToString().ToLower()+"'>";
            string tableRowClosing = "</tr>";
            string prijsStr = "<td>€17,50</td>";
            string timeStr = "<td>" + Hour.ToString() + ":" + Minutes.ToString("00") + "</td>";
            string tourStr = "<td id='"+EventId+"'>" + TicketAvailable + "</td>";

            string htmlGenerated = "";

            int startingPoint = ((EventId - StartingPoint) + 1) % 3;

            if (startingPoint == 1)
            {
                htmlGenerated += tableRowOpening + timeStr + prijsStr;
                htmlGenerated += tourStr;
            }
            else if (startingPoint == 2)
            {
                htmlGenerated += tourStr;
            }
            else if (startingPoint == 0)
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