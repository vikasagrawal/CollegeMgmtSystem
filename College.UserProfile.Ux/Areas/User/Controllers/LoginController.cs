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
using College.UserProfile.Core.DataManagers;
using College.UserProfile.Core.DataManagerInterfaces;
using College.UserProfile.Core;

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
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index");
        }

        //
        // POST: /User/Login/Create
        [HttpPost]
        public JsonResult Create(UserLogin userlogin, string accessToken)
        {
            if (ModelState.IsValid)
            {
                bool IsUserAlreadyExists = true;
                if (!_userLoginManager.IsUserLoginExists(userlogin.EmailAddress))
                {
                    // todo: generate random verification code here and update
                    // userlogin message.
                    _userLoginManager.AddUserLogin(userlogin);
                    IsUserAlreadyExists = false;
                }

                if (userlogin.IsFacebookLogin == true)
                {
                    FaceBookConnect.AccessToken = accessToken;
                    // todo: generate random password and save;
                    userlogin = _userLoginManager.GetUserLogin(userlogin.EmailAddress);
                    IsUserAlreadyExists = false;
                }

                if (IsUserAlreadyExists)
                {
                    throw new ValidationException(Json(new { Message = string.Format(Resources.MessageResources.UserAlreadyRegisteredMessageFormat, userlogin.EmailAddress) }));
                }
                
                // todo: check user active status and email verification status and 
                // redirect to user accordingly.

                Utils.SetAuthenticationCookie(userlogin);
                var routeValues = new { area = "User" };
                var urlToRedirect = Url.Action("Index", "Profile", routeValues);
                return Json(new { redirectToUrl = urlToRedirect, Message = "Success" });

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
            var userlogin = _userLoginManager.ValidateUserLogin(userLogin.EmailAddress, userLogin.Password);
            if (userlogin == null)
            {
                throw new ValidationException(Json(new { Message = Resources.MessageResources.UserLoginValidationFailedMessage }));
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
