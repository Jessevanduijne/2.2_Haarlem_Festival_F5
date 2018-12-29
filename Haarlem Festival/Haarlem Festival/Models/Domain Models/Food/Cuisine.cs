using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.Domain_Models.Food
{
	public class Cuisine
	{
        [Key]
        public int CuisineId { get; set; }

        public string Category { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}