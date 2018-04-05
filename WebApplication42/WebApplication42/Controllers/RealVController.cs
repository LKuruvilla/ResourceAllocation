using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication42.Models;

namespace WebApplication42.Controllers
{
    [Authorize]
    public class RealVController : Controller
    {
        volunteer v = null;
        
        public ActionResult loggedin(volunteerlogin v)
        {
            ViewData["name"] = v.UserName;
            List<volunteer> x = new List<volunteer>();
            using (DBModels db = new DBModels())
            {
                x = db.volunteers.ToList();
                foreach (var y in x)
                {
                    if (y.VID == v.ID)
                        return View();
                }
                
            }
            return RedirectToAction("wrong", "Volunteer");
        }

       
    }
}
