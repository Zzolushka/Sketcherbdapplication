using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Sketcher.Controllers
{
    public class AccountController : Controller
    {
        Models.UserContext db = new Models.UserContext();
        // GET: Account
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(FormCollection collection)
        { 
            Models.User user = new Models.User() { UserLogin = collection["UserLogin"], UserPassword = collection["UserPassword"], UserPhotoPath = "http://econet.ru/assets/noavatar.png" };
            db.Users.Add(user);
            db.SaveChanges();
            FormsAuthentication.SetAuthCookie(collection["UserLogin"], true);
            return RedirectToAction("Index","home");
        }

        [HttpGet]
        public ActionResult Authorisation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorisation(FormCollection collection)
        {
            var user = db.Users.ToList().SingleOrDefault(u=>u.UserLogin == collection["UserLogin"]);
            if(user != null)
            {
                if (user.UserPassword == collection["UserPassword"])
                {
                    FormsAuthentication.SetAuthCookie(collection["UserLogin"], true);
                    return RedirectToAction("showuserifromation");
                }
                else
                {
                    ModelState.AddModelError("UserPassword", "Нет такого пароля");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("UserLogin","Нету такого пользователя");
                return View();
            }

        }

        [Authorize]
        public ActionResult ShowUserInformation()
        {
            var currentUser = db.Users.FirstOrDefault(u=>u.UserLogin == User.Identity.Name);
            return View(currentUser);
        }

        public ActionResult ShowAllUsers()
        {
            return View(db.Users);
        }


    }
}