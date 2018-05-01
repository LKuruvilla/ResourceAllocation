using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
