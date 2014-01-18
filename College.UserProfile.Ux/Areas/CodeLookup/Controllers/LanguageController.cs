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
    public class LanguageController : Controller
    {
        ICodeLookupReader _codeLookupReader;
        public LanguageController(ICodeLookupReader codeLookupReader)
        {
            _codeLookupReader = codeLookupReader;
        }
        // GET: /CodeLookup/Language/
        public JsonResult Index()
        {
            var languages = _codeLookupReader.GetCodeLookupsForLookup(CodeLookupsDesc.LANGUAGE.ToString());
            return Json(languages, JsonRequestBehavior.AllowGet);
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
