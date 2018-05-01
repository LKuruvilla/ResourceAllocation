using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication42.Models
{
    public class CreateEvent
    {
        
        public int UserID { get; set; }
        public int EventID { get; set; }

        [Required(ErrorMessage = "A description is required")]
        [StringLength(256, ErrorMessage = "Must be between 5 and 256 characters", MinimumLength = 5)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [StringLength(128, ErrorMessage = "Must be between 5 and 128 characters", MinimumLength = 5)]
        public string street { get; set; }

        [StringLength(128, ErrorMessage = "Must not be more than 128 characters")]
        public string street2 { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(32, ErrorMessage = "Must be between 1 and 32characters", MinimumLength = 1)]
        public string city { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(20, ErrorMessage = "Must be between 4 and 20 characters", MinimumLength = 4)]
        public string state { get; set; }

        [Required(ErrorMessage = "Zipcode is required")]
        public string zipcode { get; set; }
    }
}