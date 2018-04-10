using System;
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
        public ActionResult Create()
        {
<<<<<<< HEAD
            return View(new CreateEvent());
=======
            return View();
>>>>>>> 29fed5ee94e5fee66b443b706ba64e4a4bac6165
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(CreateEvent c)
        {
            using(DBModels db = new DBModels())
            {
                eve e = new eve();
                e.EventID = c.EventID;
                e.Description = c.Description;
                e.UserID = c.UserID;/// must add later
                db.eves.Add(e);

                eventaddress ea = new eventaddress();
                ea.Street = c.street;
                ea.Street2 = c.street2;
                ea.city = c.city;
                ea.state = c.state;
                ea.zipcode = c.zipcode;
                db.eventaddresses.Add(ea);

                db.SaveChanges();

                ViewBag.Message = "You event has been posted. Event id is " + ea.EventID.ToString();

            }
            
                return View();
            
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
