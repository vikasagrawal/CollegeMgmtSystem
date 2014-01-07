using College.UserProfile.Core.Authentication;
using College.UserProfile.Entities;
using College.UserProfile.Ux.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult GetUserProfileInformation()
        {
            string userId = Utils.GetAutheticatedUserData();

            if (!String.IsNullOrEmpty(userId))
            {
                int id;
                if (Int32.TryParse(userId, out id))
                {
                    var user = db.Users.SingleOrDefault(x => x.UserID == id);
                    var userProfile = new College.UserProfile.Core.Models.UserProfile();
                    userProfile.user = new Entities.User();
                    if (user != null)
                    {
                        userProfile.user = user;
                    }
                    return Json(userProfile, JsonRequestBehavior.AllowGet);
                }
            }

            throw new UnauthorizedAccessException();
        }

    }
}
