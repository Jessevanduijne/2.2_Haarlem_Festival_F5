using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Haarlem_Festival.Models.Domain_Models.General;
using System.ComponentModel.DataAnnotations;

namespace Haarlem_Festival.Models.Domain_Models.Historic
{
	public class HistoricEvent : Event
    {
        [Key]
        public int TourID { get; set; }

        //[ForeignKey("Guide")]
        public int GuideID { get; set; }
    }
}