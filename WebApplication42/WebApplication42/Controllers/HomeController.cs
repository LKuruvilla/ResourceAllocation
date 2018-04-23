using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication42.Models;

namespace WebApplication42.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            using (DBModels db = new DBModels())
            {

                

                for (int j = 0; j < 3; j++)
                {




                    for (int i = 0; i < 3; i++)
                    {


                        WebClient client = new WebClient();


                        string stream = client.DownloadString("https://maps.googleapis.com/maps/api/distancematrix/json?origins=413+san+jacinto+street+la+porte+texas+77571&destinations=2305+bay+area+blvd+houston+texas+77058&key=AIzaSyDghQ0T59XCXI4_-2PEj_0OJnCM2XrynZU");
                        GlossaryTransferObject glossaryTransfer = Newtonsoft.Json.JsonConvert.DeserializeObject<GlossaryTransferObject>(stream);
                        int time = glossaryTransfer.rows[0].elements[0].duration.value;

                    }
                }

            }
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