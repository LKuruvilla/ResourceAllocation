using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication42.Models
{
    public class reqtab
    {

        public int HID { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string MiddleInitial { get; set; }

        [Required]
        [Phone]
        public long Phone { get; set; }

        [Required]
        [EmailAddress]
        public string EMail { get; set; }

        [Required]
        public string description { get; set; }
        [Required]
        public string Street { get; set; }

        public string Apt { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }
    }
}