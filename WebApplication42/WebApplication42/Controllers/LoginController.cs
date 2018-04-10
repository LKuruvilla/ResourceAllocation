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
                        String u = userid;
                        String p = pass;
                        FormsAuthentication.SetAuthCookie(vl.userName, false);
                       // return RedirectToAction("loggedin", "AccessCheck", vl);
                        return View("loggedin");
                    }
                }

            }
            ViewBag.Message = "Wrong username or password";
            return View();
        }
        // POST: Login/Create
        public ActionResult loggedin()
        {
            return View();
        }
    }
}
