using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.Domain_Models.General
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        // Properties:
        public int GrandTotal { get; set; }
        public int GrandAmount { get; set; }

        // Collections:
        public IEnumerable<OrderItem> OrderItems { get; set; }


    }
}