using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication42.Models;

namespace WebApplication42.Controllers
{
    
    public class RequestController : Controller
    {
        // GET: Request
        public ActionResult Index()
        {
            return View();
        }

        // GET: Request/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Request/Create
        public ActionResult Create(int id)
        {
            reqtab rt = new reqtab();
            rt.eventID = id;
            using(DBModels db = new DBModels())
            {
                var resourc = db.resourcetypes.ToList<resourcetype>().ToList();
                rt.resourceList = new SelectList(resourc.Select(x => new { Value = x.ResourceID, Text = x.Description }),
                   "Value",
                   "Text"
                   );

             }
            return View(rt);
        }

        // POST: Request/Create
        [HttpPost]
        public ActionResult Create(reqtab v)
        {
            using (DBModels db = new DBModels())
            {
                //string name = HttpContext.User.Identity.Name;


                requsetaddress ra = new requsetaddress();
                ra.city = v.City;
                ra.street = v.Street;
                ra.street2 = v.Apt;
                ra.state = v.State;
                ra.zipcode = v.ZipCode;
                ra.ReqAddID = v.RequestaddID;
                ra.RequestID = v.RequestID;


                db.requsetaddresses.Add(ra);

                requestresource rs = new requestresource();
                rs.RequestID = v.RequestID;
                rs.Amount = v.amount;
                rs.Description = v.description;
                rs.Delivered = v.delivered;
                rs.EventID = v.eventID;
                rs.ResourceID = v.resourceID;
                rs.userID = v.userID;

                db.requestresources.Add(rs);



                db.SaveChanges();
            }
            return RedirectToAction("Posted");

            //We have an error return the model to the view
            return View();//v);
        }
        public ActionResult Posted()
        {
            ViewBag.Message = "Your request has been posted";
            return View();
        }

        // GET: Request/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Request/Edit/5
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

        // GET: Request/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Request/Delete/5
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
