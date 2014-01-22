using College.UserProfile.Core;
using College.UserProfile.Core.Authentication;
using College.UserProfile.Core.DataManagerInterfaces;
using College.UserProfile.Core.Exceptions;
using College.UserProfile.Entities;
using College.UserProfile.Ux.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace College.UserProfile.Ux.Areas.User.Controllers
{
    [Authorize]
    [HandleUIException]
    [OutputCache(Duration = 0)]
    public class ProfileController : Controller
    {
        IUserProfileManager _userProfileManager;
        public ProfileController(IUserProfileManager userProfileManager)
        {
            _userProfileManager = userProfileManager;
        }
        //
        // GET: /User/Profile/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /User/Profile/GetUserProfileInformation
        public ActionResult GetUserProfileInformation()
        {
            int userLoginID = UserContext.CurrentUserLoginID;

            if (userLoginID > 0)
            {
                var userProfile = _userProfileManager.GetUserProfile(userLoginID);
                return Json(userProfile, JsonRequestBehavior.AllowGet);
            }

            throw new UnauthorizedAccessException();
        }

        //
        // POST: /User/Profile/Create
        [HttpPost]
        public JsonResult CreateOrUpdate(College.UserProfile.Core.Models.UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                userProfile = _userProfileManager.AddOrUpdateUserProfile(userProfile);
                var routeValues = new { area = "User" };
                var urlToRedirect = Url.Action("Index", "CollegeSelection", routeValues);
                UserContext.CurrentUserID = userProfile.user.UserID;
                return Json(new { userProfile = userProfile, redirectToUrl = urlToRedirect, Message = Resources.MessageResources.UserProfileSaveSuccessMessage });
            }
            else
            {
                string errormsg = string.Empty;
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {

                        errormsg = error.ErrorMessage;
                    }
                }

                throw new GeneralException(Json(new { userProfile = userProfile, Message = errormsg }));
            }
        }

        [HttpPost]
        public JsonResult UploadImage(FormCollection data)
        {
            if (Request.Files["files"] != null)
            {
                string fileExtention = System.IO.Path.GetExtension(Request.Files["files"].FileName);
                using (var binaryReader = new System.IO.BinaryReader(Request.Files["files"].InputStream))
                {
                    var Imagefile = binaryReader.ReadBytes(Request.Files["files"].ContentLength);//your image
                    System.IO.File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "Upload/" + UserContext.CurrentUserLoginID.ToString() + fileExtention, Imagefile);
                }
                return Json(new { FileName = UserContext.CurrentUserLoginID.ToString() + fileExtention, Message = Resources.MessageResources.UserProfileImageSaveSuccessMessage });
            }
            else
            {
                throw new ValidationException(Json(new { Message = Resources.MessageResources.UserProfileImageInvalidMessage }));
            }


        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _userProfileManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
