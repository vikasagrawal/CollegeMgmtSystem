using College.UserProfile.Core.Exceptions;
using College.UserProfile.Entities;
using College.UserProfile.Ux.CustomAttributes;
using College.UserProfile.Core.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using College.UserProfile.Core.EntityProviders;
using College.UserProfile.Core.EntityInterfaces;

namespace College.UserProfile.Ux.Areas.User.Controllers
{
    [HandleUIException]
    [OutputCache(Duration = 0)]
    public class LoginController : Controller
    {
        private IUserLoginManager _userLoginManager;

        public LoginController(IUserLoginManager userLoginManager)
        {
            _userLoginManager = userLoginManager;
        }

        //
        // GET: /User/Login/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        //
        // POST: /User/Login/Create
        [HttpPost]
        public JsonResult Create(UserLogin userlogin)
        {
            if (ModelState.IsValid)
            {
                if (!_userLoginManager.IsUserLoginExists(userlogin.EmailAddress))
                {
                    _userLoginManager.AddUserLogin(userlogin);

                    Utils.SetAuthenticationCookie(userlogin);
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
                var ModelStateError = from e in ModelState
                                      where e.Value.Errors.Count > 0
                                      select
                                          e.Value.Errors[0].ErrorMessage;


                throw new GeneralException(Json(new { userlogin = userlogin, Message = ModelStateError }));
            }
        }

        [HttpPost]
        public ActionResult ValidateUserLogin(UserLogin userLogin)
        {
            var userlogin = _userLoginManager.GetUserLogin(userLogin.EmailAddress, userLogin.Password);
            if (userlogin == null)
            {
                throw new ValidationException(Json(new { Message = string.Format("Invalid Email Address or Password.", userLogin.EmailAddress) }));
            }

            College.UserProfile.Core.Authentication.Utils.SetAuthenticationCookie(userlogin);
            var routeValues = new { area = "User" };
            var urlToRedirect = Url.Action("", "Profile", routeValues);
            return Json(new { redirectToUrl = urlToRedirect, Message = "Success" });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _userLoginManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
