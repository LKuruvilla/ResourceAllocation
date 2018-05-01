using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication42.Models
{
    public class reqtab
    {

        public int RequestID { get; set; }

        public int RequestaddID { get; set; }

        public int userID { get; set; }

        public int resourceID { get; set; }

        public int delivered { get; set; }

        public int eventID { get; set; }

        public SelectList resourceList { get; set; }


        [Required(ErrorMessage = "An amount is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int amount { get; set; }

        [Required(ErrorMessage = "A description is required")]
        [StringLength(256, ErrorMessage = "Must be between 5 and 256 characters", MinimumLength = 5)]
        public string description { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [StringLength(128, ErrorMessage = "Must be between 5 and 128 characters", MinimumLength = 5)]
        public string Street { get; set; }

        [StringLength(128, ErrorMessage = "Must not be more than 128 characters")]
        [Display(Name="Street 2")]
        public string Apt { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(32, ErrorMessage = "Must be between 1 and 32characters", MinimumLength = 1)]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(20, ErrorMessage = "Must be between 4 and 20 characters", MinimumLength = 4)]
        public string State { get; set; }

        [Required(ErrorMessage = "Zipcode is required")]
        public string ZipCode { get; set; }
    }
}