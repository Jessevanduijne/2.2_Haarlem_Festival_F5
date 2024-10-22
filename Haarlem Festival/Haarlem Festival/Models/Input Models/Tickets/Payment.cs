﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Haarlem_Festival.Models.Input_Models.Tickets
{
    public class Payment
    {        
        [Display(Name = "First name"), Required(ErrorMessage = "Please enter your first name")]        
        public string FirstName { get; set; }

        [Display(Name = "Last name"), Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of birth"), Required(ErrorMessage = "Please enter your date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "E-mail"), Required(ErrorMessage = "Please enter your e-mail")]
        public string Email { get; set; }

        // Dropdownlist:
        [Display(Name = "Payment method")]
        public List<string> PaymentMethods { get; set; }
        
        [Required(ErrorMessage = "Please select a payment method")]
        public string SelectedPaymentMethod { get; set; }
    }
}