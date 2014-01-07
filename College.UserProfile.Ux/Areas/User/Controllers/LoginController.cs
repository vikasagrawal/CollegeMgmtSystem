using College.UserProfile.Core.Exceptions;
using College.UserProfile.Entities;
using College.UserProfile.Ux.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace College.UserProfile.Ux.Areas.User.Controllers
{
    public class LoginController : Controller
    {
        private UserProfilesContext db = new UserProfilesContext();

        //
        // GET: /User/Login/
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /User/Login/Create
        [HttpPost]
        [HandleUIException]
        public JsonResult Create(UserLogin userlogin)
        {
            if (ModelState.IsValid)
            {
                if (!UserLoginExists(userlogin.EmailAddress))
                {
                    db.UserLogins.Add(userlogin);
                    db.SaveChanges();

                    College.UserProfile.Core.Authentication.Utils.SetAuthenticationCookie(userlogin);
                    var routeValues = new { area = "User", id = userlogin.UserLoginID };
                    var urlToRedirect = Url.Action("Index", "Profile", routeValues);
                    return Json(new { redirectToUrl = urlToRedirect, Message = "Success" });

                }
                else
                {
                    throw new ValidationException(Json(new { Message = string.Format("User with email address '{0}' already registered.", userlogin.EmailAddress) }));
                }
            }
            else
            {
                throw new GeneralException(Json(userlogin));
            }
        }

        [HttpPost]
        [HandleUIException]
        public ActionResult ValidateUserLogin(UserLogin userLogin)
        {
            UserLogin userlogin = db.UserLogins.SingleOrDefault(usr => usr.EmailAddress.Equals(userLogin.EmailAddress, StringComparison.OrdinalIgnoreCase)
                && usr.Password == userLogin.Password);
            if (userlogin == null)
            {
                throw new ValidationException(Json(new { Message = string.Format("Invalid Email Address or Password.", userLogin.EmailAddress) }));
            }

            College.UserProfile.Core.Authentication.Utils.SetAuthenticationCookie(userlogin);
            var routeValues = new { area = "User", id = userlogin.UserLoginID };
            var urlToRedirect = Url.Action("Index", "Profile", routeValues);
            return Json(new { redirectToUrl = urlToRedirect, Message = "Success" });
        }

        private bool UserLoginExists(string emailAddress)
        {
            return db.UserLogins.Count(e => e.EmailAddress.Equals(emailAddress, StringComparison.OrdinalIgnoreCase)) > 0;
        }
    }
}
