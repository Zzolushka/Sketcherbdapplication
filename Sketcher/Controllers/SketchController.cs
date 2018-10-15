using Sketcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sketcher.Controllers
{
    public class SketchController : Controller
    {
        Models.UserContext db = new Models.UserContext();
        // GET: Sketch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddSketch()
        {
            db.Users.ToList().FirstOrDefault(u => u.UserLogin == User.Identity.Name).Sketches.ToList();
            
            User user = new User();
            return View();
        }
    }
}