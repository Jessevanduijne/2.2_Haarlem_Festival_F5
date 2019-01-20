using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Haarlem_Festival.Models.Domain_Models.General
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        // Properties 
        public float Price { get; set; }
        public int Amount { get; set; }    

        [Display(Name = "Special Request: ")]
        public string SpecialRequest { get; set; }

        // Foreign Keys
        [ForeignKey("Event")]
        public int EventId { get; set; }
        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        
        // Navigation Properties
        public virtual Event Event { get; set; }
        public virtual Order Order { get; set; }
    }
}