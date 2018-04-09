using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication42.Models;

namespace WebApplication42.Controllers
{   [Authorize]
    public class OrganizerController : Controller
    {
        // GET: Organizer
        public ActionResult Index(volunteer v)
        {

            return View();
        }

        // GET: Organizer/Details/5
        public ActionResult ViewEvents()
        {
            using(DBModels db = new DBModels())
            {
                List<@event> ev = new List< @event >();
                ev = db.events.ToList();
                if (ev.Count==0)
                    return View("NoEvents");


            }
            return View();
        }

        // GET: Organizer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organizer/Create
        [HttpPost]
        public ActionResult CreateEvent()
        {

            
        }

        // GET: Organizer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Organizer/Edit/5
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

        // GET: Organizer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Organizer/Delete/5
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
