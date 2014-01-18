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
using College.UserProfile.Core.DataReaderInterfaces;

namespace College.UserProfile.Ux.Areas.CodeLookup.Controllers
{
    [HandleUIException]
    public class CourseFieldController : Controller
    {
        ICodeLookupReader _codeLookupReader;
        public CourseFieldController(ICodeLookupReader codeLookupReader)
        {
            _codeLookupReader = codeLookupReader;
        }

        // GET: /CodeLookup/CourseField/
        public JsonResult Index()
        {
            var courseFields = _codeLookupReader.GetCodeLookupsForLookup(CodeLookupsDesc.COURSEFIELD.ToString());

            return Json(courseFields, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _codeLookupReader.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
