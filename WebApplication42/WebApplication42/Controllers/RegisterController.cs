using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication42.Models;

namespace WebApplication42.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Volunteer
        public ActionResult Index()
        {
            return RedirectToAction("Register");
        }

        // GET: Volunteer/Create
        public ActionResult Register()
        {
            return View(new voltab());
        }

        // POST: Volunteer/Create
        [HttpPost]
        public ActionResult Register(voltab v)
        {
            //if(ModelState.IsValid)
            //{ 

            using (DBModels s = new DBModels())
            {
                
            }
            return RedirectToAction("AccountRegistered");


            //If there were errors in data return view
        //}return View(v);
        }

        //successfull registration
        public ActionResult AccountRegistered()
        {
            return View();

        }

        
        // GET: Volunteer/Edit/5
        public ActionResult login()
        {
            return View();
        }

        // POST: Volunteer/Edit/5
        //[HttpPost]
        //public ActionResult login()
        //{
            
        //    ViewBag.Message = "Wrong username or password";
        //    return View();
        //}

        

       

        
    }
}
