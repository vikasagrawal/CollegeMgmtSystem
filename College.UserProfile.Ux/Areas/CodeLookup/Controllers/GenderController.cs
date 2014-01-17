﻿using System;
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
    public class GenderController : Controller
    {
        private UserProfilesContext db = new UserProfilesContext();

        // GET: /CodeLookup/Gender/
        public JsonResult Index()
        {
            var genders = from c1 in db.CodeLookups.AsEnumerable()
                          where c1.CodeDesc.Equals(CodeLookupsDesc.GENDER.ToString(), StringComparison.OrdinalIgnoreCase) && c1.ParentCodeLookupId == null
                          join c2 in db.CodeLookups on c1.CodeLookupId equals c2.ParentCodeLookupId
                          select new
                          {
                              LookupID = c2.CodeLookupId,
                              LookupValue = c2.ShortDesc
                          };

            return Json(genders, JsonRequestBehavior.AllowGet);
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
