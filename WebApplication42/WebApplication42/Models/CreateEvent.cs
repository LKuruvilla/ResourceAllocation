using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication42.Models
{
    public class CreateEvent
    {
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
    }
}