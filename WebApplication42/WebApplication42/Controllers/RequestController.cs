using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication42.Models;

namespace WebApplication42.Controllers
{
    [Authorize]
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
        public ActionResult Create()
        {
            return View(new reqtab());
        }

        // POST: Request/Create
        [HttpPost]
        public ActionResult Create(reqtab v)
        {
            if (ModelState.IsValid)
            {
                using (DBModels s = new DBModels())
                {
                    req_addr y = new req_addr();
                    y.Apt = v.Apt;
                    y.City = v.City;
                    y.State = v.State;
                    y.ZipCode = v.ZipCode;
                    y.Street = v.Street;
                    y.HID = v.HID;


                    s.req_addr.Add(y);


                    req_desc x = new req_desc();
                    x.HID = v.HID;
                    x.description = v.description;

                    s.req_desc.Add(x);

                    request vo = new request();
                    vo.HID = v.HID;
                    vo.FirstName = v.FirstName;
                    vo.MiddleInitial = v.MiddleInitial;
                    vo.LastName = v.LastName;
                    vo.Phone = v.Phone;
                    vo.EMail = v.EMail;


                    s.requests.Add(vo);
                    s.SaveChanges();

                }
                return View("Posted");
            }

            //We have an error return the model to the view
            return View(v);
        }
        public ActionResult Posted(request r)
        {
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
