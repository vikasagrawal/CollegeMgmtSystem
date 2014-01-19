using College.UserProfile.Ux.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace College.UserProfile.Ux.Areas.User.Controllers
{
    [HandleUIException]
    [OutputCache(Duration = 0)]
    public class CollegeSelectionController : Controller
    {
        //
        // GET: /User/CollegeSelection/
        public ActionResult Index()
        {
            return View();
        }
	}
}