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
    public class VolunteerController : Controller
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
        public ActionResult Register(voltab v )
        {
            if (ModelState.IsValid)
            {
                
                using (DBModels s = new DBModels())
                {
                    var vregister = s.volunteers.SingleOrDefault(x => x.FirstName == v.FirstName && x.LastName == v.LastName
                    && x.DOB == v.DOB);

                    var vlregister = s.volunteerlogins.SingleOrDefault(x => x.UserName == v.UserName);

                    if (vregister != null || vlregister !=null)
                    {
                        ViewBag.message = "existing account";
                        ViewBag.x = "yes";
                        return View();
                    }

                    

                    else {
                        volunteer vo = new volunteer();
                        vo.VID = v.VID;
                        vo.FirstName = v.FirstName;
                        vo.MiddleInitial = v.MiddleInitial;
                        vo.LastName = v.LastName;
                        vo.Phone = v.Phone;
                        vo.EMail = v.EMail;
                        vo.DOB = v.DOB;

                        s.volunteers.Add(vo);

                        vol_addr y = new vol_addr();
                        y.Apt = v.Apt;
                        y.City = v.City;
                        y.State = v.State;
                        y.ZipCode = v.ZipCode;
                        y.Street = v.Street;
                        y.VID = v.VID;


                        s.vol_addr.Add(y);

                        volunteerlogin x = new volunteerlogin();
                        x.ID = v.VID;
                        x.UserName = v.UserName;
                        x.Password = v.Password;

                        s.volunteerlogins.Add(x);

                        s.SaveChanges();
                    }
                }
                return RedirectToAction("AccountRegistered");
            }

            //If there were errors in data return view
            return View(v);
        }

        //successfull registration
        public ActionResult AccountRegistered(volunteer v)
        {
            return View();

        }

        
        // GET: Volunteer/Edit/5
        public ActionResult login()
        {
            return View();
        }

        // POST: Volunteer/Edit/5
        [HttpPost]
        public ActionResult login(volunteerlogin v)
        {
            String userid = v.UserName;
            String pass = v.Password;

            List<volunteerlogin> loginlist = new List<volunteerlogin>();
            using(DBModels db = new DBModels())
            {
                loginlist = db.volunteerlogins.ToList();

                foreach (var vl in loginlist)
                {
                    if (vl.UserName.Equals(userid) && vl.Password.Equals(pass))
                    {
                        String u = userid;
                        String p = pass;
                        FormsAuthentication.SetAuthCookie(vl.UserName, false);
                        return RedirectToAction("loggedin","RealV", vl);
                    }
                }

            }

            return View("wrong");
        }

        //Wrong username or password
        public ActionResult wrong()
        {
            return View();
        }

       

        
    }
}
