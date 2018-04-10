using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication42.Models
{
    public class CreateEvent
    {
<<<<<<< HEAD

        public string Description { get; set; }
        public int UserID { get; set; }
        public int EventID { get; set; }

    
        public string street { get; set; }
        public string street2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }

   
=======
        //Event Table


        public string Description;
        public int UserID;
        public int EventID;

        //Event Address Table

        public string street;
        public string street2;
      
        public string city;
     
        public string state;
        
        public string zipcode;
>>>>>>> 0634a80aaac1f9c247e561f3e2935a7d1e4b2ac2
    }
}