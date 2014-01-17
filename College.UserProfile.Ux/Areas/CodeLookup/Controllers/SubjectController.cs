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
    public class SubjectController : Controller
    {
        ISubjectReader _subjectReader;
        public SubjectController(ISubjectReader subjectReader)
        {
            _subjectReader = subjectReader;
        }

        // GET: /CodeLookup/Gender/
        public JsonResult Index()
        {
            var subjects = _subjectReader.GetSubjectsForLookup();
            return Json(subjects, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _subjectReader.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
