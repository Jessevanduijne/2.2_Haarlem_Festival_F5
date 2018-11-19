using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.Domain_Models.Food
{
    public enum Cuisine
    {
        Dutch = 1, 
        [Display(Name ="Fish and Seafood")]
        Fish = 2,
        European = 3,
        French = 4,
        International = 5,
        Asian = 6,
        Modern = 7,
        Steakhouse = 8,
        Argentinian = 9
    }
}