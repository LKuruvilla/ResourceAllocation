using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication42.Models
{
    public class EventDetails
    {
        public eve evelocal { get; set; }
        public List<volunteerresource> volunteers { get; set; }
        public List<requestresource> requests { get; set; }
        public List<resourcetype> resourceType { get; set; }
        public SelectList resourceList { get; set; }
        public int resourceID { get; set; }
        public int eventID { get; set; }

        public Dictionary<volunteerresource, requestresource> assignedPairs { get; set; }

    }
}