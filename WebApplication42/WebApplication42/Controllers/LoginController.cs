using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication42.Models;

namespace WebApplication42.Controllers
{
    public class LoginController : Controller
    {
        
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(user v)
        {
            String userid = v.userName;
            String pass = v.Password;

            List<user> loginlist = new List<user>();
            using (DBModels db = new DBModels())
            {
                loginlist = db.users.ToList();

                foreach (var vl in loginlist)
                {
                    if (vl.userName.Equals(userid) && vl.Password.Equals(pass))
                    {
                        String user = vl.UserID.ToString();
                        String u = userid;
                        String p = pass;
                        FormsAuthentication.SetAuthCookie(vl.userName, false);
                       

                        // return RedirectToAction("loggedin", "AccessCheck", vl);
                        var use = db.userinformations.SingleOrDefault(x => x.UserID.ToString() == user);
                        //  return RedirectToAction("Index", "Home", use);
                        List<userinformation> uinformation = new List<userinformation>();
                        uinformation = db.userinformations.ToList();
                        String name = null;
                        foreach (var v2 in uinformation)
                        {
                            if (vl.UserID.Equals(v2.UserID))
                                name = v2.FirstName.ToString() +" " +v2.LastName.ToString();
                        }
                        ViewBag.Message = "Welcome " + name + "!";
                        return View("../Home/Index");
                    }
                }

            }
            ViewBag.Message = "Wrong username or password";
            return View();
        }
        // POST: Login/Create
        public ActionResult loggedin(String name)
        {
            ViewBag.Message = name +" has logged in";
            return View("Home/Index");
        }

        public ActionResult Logout()
        {
            if(User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                ViewBag.message = "You have been logged out!";
                return View("../Home/Index");
            }
            else
            {
                ViewBag.message = "No one is logged in!";
                return View("../Home/Index");
            }
        }
    }
}
