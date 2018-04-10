﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication42.Models;

namespace WebApplication42.Controllers
{

    [Authorize]
    public class EventController : Controller
    {
        userinformation u = new userinformation();
        public ActionResult Index()
        {
<<<<<<< HEAD
            List<eve> eves = new List<eve>();
            using (DBModels db = new DBModels())
            {
                eves = db.eves.ToList<eve>();
            }
            ListModel<eve> evesModel = new ListModel<eve>(eves);

            return View(evesModel);
        }
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

=======
            return View(new CreateEvent());
>>>>>>> 0634a80aaac1f9c247e561f3e2935a7d1e4b2ac2
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(CreateEvent c)
        {
            string name = HttpContext.User.Identity.Name;
            
            using (DBModels db = new DBModels())
            {
                int userId  = db.users.SingleOrDefault(x => x.userName == name).UserID;

                eve e = new eve();
                e.EventID = c.EventID;
                e.Description = c.Description;
<<<<<<< HEAD
                e.UserID = userId; 
=======
                e.UserID =1;/// must add later
>>>>>>> 0634a80aaac1f9c247e561f3e2935a7d1e4b2ac2
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

        public ActionResult Posted()
        {
            return View();
        }
    }
}
