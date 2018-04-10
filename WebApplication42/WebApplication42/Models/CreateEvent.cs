using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication42.Models
{
    public class CreateEvent
    {
        //Event Table
<<<<<<< HEAD
        public string Description { get; set; }
        public int UserID { get; set; }
        public int EventID { get; set; }

        //Event Address Table
        public string street { get; set; }
        public string street2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
=======
        public string Description;
        public int UserID;
        public int EventID;

        //Event Address Table
        public string street;
        public string street2;
        public string city;
        public string state;
        public string zipcode;
>>>>>>> 29fed5ee94e5fee66b443b706ba64e4a4bac6165
    }
}