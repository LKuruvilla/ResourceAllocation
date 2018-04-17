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

        public int amount { get; set; }

        public int resourceID { get; set; }

        public int delivered { get; set; }
        public int eventID { get; set; }
        public SelectList resourceList { get; set; }



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