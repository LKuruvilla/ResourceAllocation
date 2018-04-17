using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication42.Models;

namespace WebApplication42.Controllers
{
    public class VolunteerController : Controller
    {
        // GET: Volunteer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Volunteer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Volunteer/Create
        public ActionResult Create(int id)
        {
            voltab vtab = new voltab();

            vtab.EventID = id;

            using (DBModels db = new DBModels())
            {

                var resourc = db.resourcetypes.ToList<resourcetype>().ToList();
                vtab.resourceList = new SelectList(resourc.Select(x => new { Value = x.ResourceID , Text = x.Description}),
                   "Value",
                   "Text"
                   );
            }


            return View(vtab);
        }

        // POST: Volunteer/Create
        [HttpPost]
        public ActionResult Create(voltab v)
        {
            try
            {
                using (DBModels db = new DBModels())
                {
                    string name = HttpContext.User.Identity.Name;

                    v.UserID = db.users.SingleOrDefault(x => x.userName == name).UserID;

                    volunteerresource vSource = new volunteerresource();
                    vSource.Amount = v.Amount;
                    vSource.Delivered = 0;
                    vSource.Description = v.Description;
                    vSource.EventID = v.EventID;
                    vSource.ResourceID = v.ResourceID;
                    vSource.UserID = v.UserID;

                    db.volunteerresources.Add(vSource);
                    
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Volunteer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Volunteer/Edit/5
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

        // GET: Volunteer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Volunteer/Delete/5
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
