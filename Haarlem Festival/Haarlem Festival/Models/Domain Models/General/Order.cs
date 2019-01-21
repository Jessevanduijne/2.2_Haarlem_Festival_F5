using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Haarlem_Festival.Models.Domain_Models.General
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        // Properties
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Email { get; set; }
        public bool IsPaid { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime OrderPlaced { get; set; }

        // Collections:
        public List<Ticket> Tickets { get; set; }
    }
}