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
        public string GetGuideName { get { return "Alibaba"; } }
    }
}