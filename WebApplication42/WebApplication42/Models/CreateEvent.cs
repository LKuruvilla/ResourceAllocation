using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication42.Models
{
    public class CreateEvent
    {
        //Event Table
        string Description;
        int UserID;
        int EventID;

        //Event Address Table
        string street;
        string street2;
        string city;
        string state;
        string zipcode;
    }
}