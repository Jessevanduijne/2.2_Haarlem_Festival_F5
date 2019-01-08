using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.Domain_Models.Historic
{
    public class Guide
    {
        [Key]
        public int GuideID { get; set; }

        // Properties
        public string Name { get; set; }
        public string Language { get; set; }
    }
}