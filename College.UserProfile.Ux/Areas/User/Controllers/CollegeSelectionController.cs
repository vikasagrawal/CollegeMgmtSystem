using College.UserProfile.Core.DataManagerInterfaces;
using College.UserProfile.Core.DataReaderInterfaces;
using College.UserProfile.Core.Exceptions;
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
        IUserShortListedCollegesReader _userShortListedCollegesReader;
        IUserShortListedCollegesManager _userShortListedCollegesManager;
        public CollegeSelectionController(IUserShortListedCollegesReader userShortListedCollegesReader, IUserShortListedCollegesManager userShortListedCollegesManager)
        {
            _userShortListedCollegesReader = userShortListedCollegesReader;
            _userShortListedCollegesManager = userShortListedCollegesManager;
        }
        //
        // GET: /User/CollegeSelection/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCollegeSelection()
        {
            int userID = UserContext.CurrentUserID;
            return Json(_userShortListedCollegesReader.GetUserShortListedColleges(userID), JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /User/Profile/Create
        [HttpPost]
        public JsonResult CreateOrUpdate(List<int> shortListedColleges)
        {
            if (ModelState.IsValid)
            {
                _userShortListedCollegesManager.AddOrUpdate(UserContext.CurrentUserID, shortListedColleges);
                var routeValues = new { area = "User" };
                var urlToRedirect = Url.Action("Index", "CollegeSelection", routeValues);
                return Json(new { Message = Resources.MessageResources.UserCollegeShortlistingSaveSuccessMessage });
            }
            else
            {
                string errormsg = string.Empty;
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {

                        errormsg = error.ErrorMessage;
                    }
                }

                throw new GeneralException(Json(new { Message = errormsg }));
            }
        }
    }
}