using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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