using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication42.Models;

namespace WebApplication42.Controllers
{
    [Authorize]
    public class AccessCheckController : Controller
    {
        volunteer vol = null;
        
        public ActionResult loggedin(userlogin v)
        {
            ViewData["name"] = v.UserName;
            List<volunteer> x = new List<volunteer>();
            using (DBModels db = new DBModels())
            {
                x = db.volunteers.ToList();
                foreach (var y in x)
                {
                    if (y.VID== v.ID)
                    {   vol = db.volunteers.SingleOrDefault(m => m.VID == y.VID);

                        if (vol.permission == 1)
                            return RedirectToAction("Index", "Volunteer",vol);
                        else
                            return RedirectToAction("Index", "Organizer",vol);
                    }
                        
                }
                
            }
            //will never return;
            return RedirectToAction("Index", "Home");
        }

       
    }
}
