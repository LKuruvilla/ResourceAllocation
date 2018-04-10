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

            using (DBModels db = new DBModels())
            {
                user u = new user();
                u.UserID = v.userid;
                u.userName = v.UserName;
                u.Password = v.Password;

                db.users.Add(u);

                useraddress ua = new useraddress();
                ua.AddID = v.addid;
                ua.Street = v.Street;
                ua.Street2 = v.Street2;
                ua.city = v.City;
                ua.zipcode = v.ZipCode;
                ua.state = v.State;
                ua.UserID = v.userid;

                db.useraddresses.Add(ua);

                userinformation ui = new userinformation();
                ui.UiID = v.UiID;
                ui.FirstName = v.FirstName;
                ui.LastName = v.LastName;
                ui.MiddleInitial = v.MiddleInitial;
                ui.Phone = v.Phone.ToString();
                ui.Email = v.EMail;
                ui.UserID = v.userid;

                db.userinformations.Add(ui);

                db.SaveChanges();







                
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
