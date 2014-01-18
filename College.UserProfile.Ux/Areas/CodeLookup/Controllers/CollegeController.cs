using College.UserProfile.Core.DataReaderInterfaces;
using College.UserProfile.Ux.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace College.UserProfile.Ux.Areas.CodeLookup.Controllers
{
    [HandleUIException]
    public class CollegeController : Controller
    {
        ICollegeReader _collegeReader;
        public CollegeController(ICollegeReader collegeReader)
        {
            _collegeReader = collegeReader;
        }

        // GET: /CodeLookup/College/
        public JsonResult Index()
        {
            var courses = _collegeReader.GetCollegesForLookup();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _collegeReader.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}