using College.UserProfile.Core;
using College.UserProfile.Core.Authentication;
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
        private UserProfilesContext db = new UserProfilesContext();
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
            string userLoginID = Utils.GetAutheticatedUserData();

            if (!String.IsNullOrEmpty(userLoginID))
            {
                int id;
                if (Int32.TryParse(userLoginID, out id))
                {
                    var user = db.Users.SingleOrDefault(x => x.UserLoginID == id);
                    var userProfile = new College.UserProfile.Core.Models.UserProfile();
                    userProfile.user = new Entities.User() { UserLoginID = Int32.Parse(userLoginID), UserID = 0 };
                    userProfile.UserEducationDetail = new List<UserEducationDetail>();
                    if (user != null)
                    {
                        userProfile.user = user;
                        userProfile.UserEducationDetail = db.UserEducationDetails.Where(x => x.UserId == user.UserID).ToList<UserEducationDetail>();
                    }
                    return Json(userProfile, JsonRequestBehavior.AllowGet);
                }
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
                userProfile.user.LanguagesSpoken = Helper.ListToXMLString(userProfile.UserLanguages, Constants.LanguagesRootElementName, Constants.LanguagesElementName);

                Entities.User existingUser = GetUser(userProfile.user.UserLoginID);
                if (existingUser == null)
                {
                    db.Users.Add(userProfile.user);
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(existingUser).CurrentValues.SetValues(userProfile.user);
                }

                var ed = from ued in db.UserEducationDetails
                         where ued.UserId == userProfile.user.UserID
                         select ued;

                if (ed.Count() > 0)
                {
                    db.UserEducationDetails.RemoveRange(ed);
                }

                if (userProfile.UserEducationDetail != null)
                {
                    foreach (var newued in userProfile.UserEducationDetail)
                    {
                        newued.UserId = userProfile.user.UserID;
                        db.UserEducationDetails.Add(newued);
                    }
                }


                db.SaveChanges();
                return Json(new { userProfile = userProfile, Message = "Profile Saved Successfully." });
            }
            else
            {
                var ModelStateError = from e in ModelState
                                      where e.Value.Errors.Count > 0
                                      select
                                          e.Value.Errors[0].ErrorMessage;


                throw new GeneralException(Json(new { userProfile = userProfile, Message = ModelStateError }));
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
                    System.IO.File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "Upload/" + Utils.GetAutheticatedUserData() + fileExtention, Imagefile);
                }
                return Json(new { FileName = Utils.GetAutheticatedUserData() + fileExtention, Message = "Image Saved Successfully." });
            }
            else
            {
                throw new ValidationException(Json(new { Message = "Invalid File." }));
            }


        }

        private Entities.User GetUser(int userLoginID)
        {
            return db.Users.SingleOrDefault(x => x.UserLoginID == userLoginID);
        }

    }
}
