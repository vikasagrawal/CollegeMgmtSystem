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
                    if (user != null)
                    {
                        userProfile.user = user;
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

                XElement el = new XElement("Languages", userProfile.UserLanguages.Select(kv => new XElement("Language", kv)));
                userProfile.user.LanguagesSpoken = el.ToString();

                Entities.User existingUser = GetUser(userProfile.user.UserLoginID);
                if (existingUser == null)
                {
                    db.Users.Add(userProfile.user);
                }
                else
                {
                    db.Entry(existingUser).CurrentValues.SetValues(userProfile.user);
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

        private Entities.User GetUser(int userLoginID)
        {
            return db.Users.SingleOrDefault(x => x.UserLoginID == userLoginID);
        }

    }
}
