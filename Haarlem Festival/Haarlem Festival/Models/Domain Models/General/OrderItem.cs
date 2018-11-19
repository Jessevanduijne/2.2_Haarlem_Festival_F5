using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.Domain_Models.General
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }
        
        // Properties:
        public int Amount { get; set; }
        public float TotalPrice { get; set; }

        // Foreign keys:
        [ForeignKey("Ticket")]
        public int TicketID { get; set; }
        public virtual Ticket Ticket { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
    }
}