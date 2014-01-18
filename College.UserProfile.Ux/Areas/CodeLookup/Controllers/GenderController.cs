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
    public class GenderController : Controller
    {
        ICodeLookupReader _codeLookupReader;
        public GenderController(ICodeLookupReader codeLookupReader)
        {
            _codeLookupReader = codeLookupReader;
        }

        // GET: /CodeLookup/Gender/
        public JsonResult Index()
        {
            var genders = _codeLookupReader.GetCodeLookupsForLookup(CodeLookupsDesc.GENDER.ToString());
            return Json(genders, JsonRequestBehavior.AllowGet);
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
