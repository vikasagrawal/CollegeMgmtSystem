using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web;
using System.Web.Mvc;
using College.UserProfile.Core;
using College.UserProfile.Ux.CustomAttributes;
using College.UserProfile.Core.EntityInterfaces;

namespace College.UserProfile.Ux.Areas.CodeLookup.Controllers
{
    [HandleUIException]
    public class DegreeTypeController : Controller
    {
        ICodeLookupReader _codeLookupReader;
        public DegreeTypeController(ICodeLookupReader codeLookupReader)
        {
            _codeLookupReader = codeLookupReader;
        }

        // GET: /CodeLookup/DegreeType/
        public JsonResult Index()
        {
            var degreeTypes = _codeLookupReader.GetCodeLookupsForLookup(CodeLookupsDesc.DEGREETYPE.ToString());
            return Json(degreeTypes, JsonRequestBehavior.AllowGet);
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
