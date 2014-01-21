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
using College.UserProfile.Core.Helpers;
using College.UserProfile.Core.Models;

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

        public ActionResult VerifyEmail(int id, string code)
        {
            object routeValues = new { area = "User" };
            UserLogin userlogin = null;

            /// if user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("", "Profile", routeValues);
            }

            // if id is null or empty
            if (id <= 0)
            {
                return RedirectToAction("", "Login", routeValues);
            }

            userlogin = _userLoginManager.GetUserLogin(id);

            // if user login doesn't exists for given id
            if (userlogin == null)
            {
                return RedirectToAction("", "Login", routeValues);
            }

            var model = new UserEmailVerification();

            if (userlogin.IsEmailVerified == true)
            {
                return RedirectToAction("", "Login", routeValues);
            }

            if (!string.IsNullOrEmpty(code))
            {
                if (!_userLoginManager.VerifyAndUpdateUserEmail(id, code))
                {
                    model.ValidationError = Resources.MessageResources.EmailVerificationCodeIsInvalidMessage;
                }
                else
                {
                    return RedirectToAction("", "Login", routeValues);
                }
            }

            model.UserLoginId = id;

            return View(model);
        }

        [HttpPost]
        public ActionResult VerifyEmail(UserEmailVerification model)
        {
            if (!string.IsNullOrEmpty(model.VerificationCode))
            {
                if (_userLoginManager.VerifyAndUpdateUserEmail(model.UserLoginId, model.VerificationCode))
                {
                    var routeValues = new { area = "User" };
                    return RedirectToAction("Index", "Login", routeValues);
                }
            }

            model.ValidationError = Resources.MessageResources.EmailVerificationCodeIsInvalidMessage;
            return View(model);
        }
        //
        // POST: /User/Login/Create
        [HttpPost]
        public ActionResult Create(UserLogin userlogin, string accessToken)
        {
            if (ModelState.IsValid)
            {
                bool IsUserAlreadyExists = true;
                if (!_userLoginManager.IsUserLoginExists(userlogin.EmailAddress))
                {
                    userlogin.VerificationCode = UserLoginHelper.GenerateRandomVerificationCode();
                    userlogin.Password = UserLoginHelper.GenerateRandomPassword();
                    _userLoginManager.AddUserLogin(userlogin);
                    IsUserAlreadyExists = false;
                }

                if (userlogin.IsFacebookLogin == true)
                {
                    FaceBookConnect.AccessToken = accessToken;
                    userlogin = _userLoginManager.GetUserLogin(userlogin.EmailAddress);
                    IsUserAlreadyExists = false;
                }

                if (IsUserAlreadyExists)
                {
                    throw new ValidationException(Json(new { Message = string.Format(Resources.MessageResources.UserAlreadyRegisteredMessageFormat, userlogin.EmailAddress) }));
                }
                object routeValues = new { area = "User" };
                var urlToRedirect = Url.Action("Index", "Profile", routeValues);

                if (userlogin.IsEmailVerified == true)
                {
                    Utils.SetAuthenticationCookie(userlogin);
                }
                else
                {
                    routeValues = new { area = "User", id = userlogin.UserLoginID };
                    urlToRedirect = Url.Action("VerifyEmail", "Login", routeValues);
                }

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
            object routeValues = new { area = "User" };
            var urlToRedirect = Url.Action("", "Profile", routeValues);
            if (userlogin == null)
            {
                throw new ValidationException(Json(new { Message = Resources.MessageResources.UserLoginValidationFailedMessage }));
            }

            if (!(userlogin.IsActive == true))
            {
                throw new ValidationException(Json(new { Message = Resources.MessageResources.UserAccountInactiveMessage }));
            }

            if (!(userlogin.IsEmailVerified == true))
            {
                routeValues = new { area = "User", id = userlogin.UserLoginID };
                urlToRedirect = Url.Action("VerifyEmail", "Login", routeValues);
            }
            else
            {
                College.UserProfile.Core.Authentication.Utils.SetAuthenticationCookie(userlogin);
            }

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
