using GraphAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication42.Models;

namespace WebApplication42.Controllers
{


    public class EventController : Controller
    {
        userinformation u = new userinformation();
        public ActionResult Index()
        {
            string name = HttpContext.User.Identity.Name;
            int userId = -1;
            List<eve> eves = new List<eve>();

            using (DBModels db = new DBModels())
            {
                if (db.users.SingleOrDefault(x => x.userName == name) != null)
                {
                    userId = db.users.SingleOrDefault(x => x.userName == name).UserID;
                }

                eves = db.eves.ToList<eve>();
            }
            ListModel<eve> evesModel = new ListModel<eve>(eves);

            evesModel.id = userId;
            return View(evesModel);
        }

        [Authorize]
        public ActionResult Create(userinformation x)
        {
            u.UiID = x.UiID;
            u.FirstName = x.FirstName;
            u.LastName = x.LastName;
            u.MiddleInitial = x.MiddleInitial;
            u.Phone = x.Phone;
            u.Email = x.Email;
            u.UserID = x.UserID;
            return View(new CreateEvent());

        }

        // POST: Event/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(CreateEvent c)
        {
            if (ModelState.IsValid)
            {
                string name = HttpContext.User.Identity.Name;

                using (DBModels db = new DBModels())
                {
                    int userId = db.users.SingleOrDefault(x => x.userName == name).UserID;

                    eve e = new eve();
                    e.EventID = c.EventID;
                    e.Description = c.Description;
                    e.UserID = userId;

                    db.eves.Add(e);

                    eventaddress ea = new eventaddress();
                    ea.Street = c.street;
                    ea.Street2 = c.street2;
                    ea.city = c.city;
                    ea.state = c.state;
                    ea.zipcode = c.zipcode;
                    db.eventaddresses.Add(ea);

                    db.SaveChanges();
                }

                ViewBag.Message = "Your event has been created.";
                return RedirectToAction("Posted");
            }

            return View(c);
        }

        [Authorize]
        public ActionResult Posted()
        {
            return View();
        }

        [Authorize]
        public ActionResult EventDetail(int id)
        {
            EventDetails detail = new EventDetails();

            using (DBModels db = new DBModels())
            {
                //Get Event data
                detail.evelocal = db.eves.Where(x => x.EventID == id).FirstOrDefault();

                detail.eventID = detail.evelocal.EventID;

                //Get requests
                detail.requests = db.requestresources.Where(x => x.EventID == id).ToList();

                //Get volunteers
                detail.volunteers = db.volunteerresources.Where(x => x.EventID == id).ToList();

                //Get Resource Types
                detail.resourceType = db.resourcetypes.ToList();

                var resourc = db.resourcetypes.ToList<resourcetype>().ToList();
                detail.resourceList = new SelectList(resourc.Select(x => new { Value = x.ResourceID, Text = x.Description }),
                    "Value",
                    "Text"
                    );
            }

            return View(detail);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EventDetail(EventDetails detail)
        {
            using (DBModels db = new DBModels())
            {
                //Get Event data
                detail.evelocal = db.eves.Where(x => x.EventID == detail.eventID).FirstOrDefault();

                detail.eventID = detail.evelocal.EventID;

                //Get requests
                detail.requests = db.requestresources.Where(x => x.EventID == detail.eventID).ToList();

                //Get volunteers
                detail.volunteers = db.volunteerresources.Where(x => x.EventID == detail.eventID).ToList();

                //Get Resource Types
                detail.resourceType = db.resourcetypes.ToList();

                var resourc = db.resourcetypes.ToList<resourcetype>().ToList();
                detail.resourceList = new SelectList(resourc.Select(x => new { Value = x.ResourceID, Text = x.Description }),
                    "Value",
                    "Text"
                    );



               List<volunteerresource> volunteer = db.volunteerresources.Where(x => x.EventID == detail.eventID).Where(x=> x.ResourceID == detail.resourceID).ToList();
                List<requestresource> requests = db.requestresources.Where(x => x.EventID == detail.eventID).Where(x => x.ResourceID == detail.resourceID).ToList();




                List<useraddress> uaO = new List<useraddress>();
                List<requsetaddress> raO = new List<requsetaddress>();


                foreach (requestresource r in requests)
                {
                    raO.Add(r.requsetaddresses.FirstOrDefault());
                }

                foreach (volunteerresource v in volunteer)
                {
                    uaO.Add(v.user.useraddresses.FirstOrDefault());
                }

                int[,] generatematrix(List<useraddress> ua, List<requsetaddress> ra) //removed parameter
                {
                    //right now it takes all volunteers and all requesters addresses
                    //this needs to be changed so that we only take addresses based on their resource type id
                    //List<useraddress> ua = new List<useraddress>();
                    //List<requsetaddress> ra = new List<requsetaddress>();

                    //ua = db.useraddresses.ToList();
                    //ra = db.requsetaddresses.ToList();

                    //some parameters to keep track
                    int size;
                    int difference1 = 0, difference2 = 0;

                    //if volunteers are more than requesteors
                    if (ua.Count > ra.Count)
                    {
                        //set the matrix size to the largest of the two
                        size = ua.Count;
                        //keep a track of how much larger volunteers are then requestors
                        difference1 = ua.Count - ra.Count;
                    }

                    else if (ra.Count > ua.Count)
                    {
                        //set the matrix size to the largest of the two
                        size = ra.Count;
                        //keep a track of how much larger requesters are then volunteers
                        difference2 = ra.Count - ua.Count;
                    }
                    else
                    {
                        //in case neither is greater than the other(both are equal) set the matrix size equal to one of their size
                        size = ra.Count;
                    }

                    var matrix = new int[size, size];//make a matrix with the greater of the two (volunteer vs requestor)sizes

                    //fill with 0's for unbalanced if volunteers are less than requesters
                    if (difference2 > 0)
                    {

                        for (int i = ua.Count; i < (ua.Count + difference2); i++)
                            for (int j = 0; j < size; j++)
                                matrix[i, j] = 0; //fills all the remaining volunteers rows with 0s
                    }

                    //fill with 0s for unblanaced if requesters are less than volunteers
                    if (difference1 > 0)
                    {

                        for (int i = size; i < ua.Count; i++)
                            for (int j = ra.Count; j < (ra.Count + difference1); j++)
                                matrix[i, j] = 0;//fills all the remaining requestor columns with 0s
                    }

                    //variables to store all the address information for volunteers and requestors
                    string vstreet, vcity, vstate, vzipcode, rstreet, rcity, rstate, rzipcode;

                    for (int i = 0; i < ua.Count; i++)
                    {
                        //for each row store the volunteer address 

                        vstreet = ua.ElementAt(i).Street;
                        vcity = ua.ElementAt(i).city;
                        vstate = ua.ElementAt(i).state;
                        vzipcode = ua.ElementAt(i).zipcode;

                        //store all address concatnated in string
                        string volunteerlocation = vstreet + " " + vcity + " " + vstate + " " + vzipcode;

                        for (int j = 0; j < size; j++)
                        {
                            //for each column store the requestors address
                            rstreet = ra.ElementAt(j).street;
                            rcity = ra.ElementAt(j).city;
                            rstate = ra.ElementAt(j).state;
                            rzipcode = ra.ElementAt(j).zipcode;

                            //this is ur code, i only modified it with the new google key (and of course address concatnation)
                            WebClient client = new WebClient();

                            string requesterlocation = rstreet + " " + rcity + " " + rstate + " " + rzipcode;
                            string location = volunteerlocation + "&destinations=" + requesterlocation;

                            //concatnate the final string and pass it.
                            string maplocation = "https://maps.googleapis.com/maps/api/distancematrix/json?origins=" + location + /*this is key, put ur key here-->*/ "&key=AIzaSyAJFKj32bxwQEquD1OYPVDUAVlMv3fMdkU";

                            string stream = client.DownloadString(maplocation);
                            GlossaryTransferObject glossarytransfer = Newtonsoft.Json.JsonConvert.DeserializeObject<GlossaryTransferObject>(stream);
                            int time = glossarytransfer.rows[0].elements[0].duration.value;

                            //so finally!!!, all the duration in time is store to their respective columns xd
                            matrix[i, j] = time;

                        }
                    }
                    //return matrix for processing
                    return matrix;
                }

                void printmatrix(int[,] matrix)
                {
                    Console.WriteLine("matrix:");
                    var size = matrix.GetLength(0);
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                            Console.Write("{0,5:0}", matrix[i, j]);
                        Console.WriteLine();
                    }
                }

                string printarray(int[] array)
                {
                    Console.WriteLine("array:");
                    string arraycost = null;
                    var size = array.Length;
                    for (int i = 0; i < size; i++)
                    {
                        Console.Write("{0,5:0}", array[i]);
                        arraycost = arraycost + " " + array[i].ToString();
                    }
                    Console.WriteLine();

                    return arraycost;
                }

                {
                    var matrix = generatematrix(uaO,raO);

                    

                    printmatrix(matrix);

                    var algorithm = new HungarianAlgorithm(matrix);

                    var result = algorithm.Run();



                    ViewBag.m = printarray(result);
                }
            }

            return View(detail);
        }
    }
}
