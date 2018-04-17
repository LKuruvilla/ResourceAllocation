using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication42.Models
{
    public class register
    {

        public int userid { get; set; }

        public int addid { get; set; }

        public int UiID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string MiddleInitial { get; set; }

        [Required]
        public long Phone { get; set; }

        [Required]
        [EmailAddress]
        public string EMail { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Street { get; set; }

        public string Street2 { get; set; }

        public string Apt { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }
    }
}