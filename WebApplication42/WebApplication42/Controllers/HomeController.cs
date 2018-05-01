using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication42.Models;
using GraphAlgorithms;

namespace WebApplication42.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Will implement at a later date";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Will be added shortly!";

            return View();
        }
    }
}

public class GlossaryTransferObject
{
    public string[] destination_addresses { get; set; }
    public string[] origin_addresses { get; set; }
    public Row[] rows { get; set; }
    public string status { get; set; }
}

public class Row
{
    public Element[] elements { get; set; }
}

public class Element
{
    public Distance distance { get; set; }
    public Duration duration { get; set; }
    public string status { get; set; }
}

public class Distance
{
    public string text { get; set; }
    public int value { get; set; }
}

public class Duration
{
    public string text { get; set; }
    public int value { get; set; }
}