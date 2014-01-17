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
using College.UserProfile.Core.EntityInterfaces;

namespace College.UserProfile.Ux.Areas.CodeLookup.Controllers
{
    [HandleUIException]
    public class CourseController : Controller
    {
        ICourseReader _courseReader;
        public CourseController(ICourseReader courseReader)
        {
            _courseReader = courseReader;
        }

        // GET: /CodeLookup/Course/
        public JsonResult Index()
        {
            var courses = _courseReader.GetCoursesForLookup();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _courseReader.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
