using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using College.UserProfile.Entities;
using College.UserProfile.Core;
using College.UserProfile.Ux.CustomAttributes;

namespace College.UserProfile.Ux.Areas.CodeLookup.Controllers
{
    [HandleUIException]
    public class SubjectController : Controller
    {
        private UserProfilesContext db = new UserProfilesContext();

        // GET: /CodeLookup/Gender/
        public JsonResult Index()
        {
            var courses = from c1 in db.Subjects
                          select new
                            {
                                LookupID = c1.SubjectId,
                                LookupValue = c1.SubjectDesc
                            };

            // genders = db.UserLogins.SingleOrDefault(usr=> usr.UserLoginID == 28);

            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
