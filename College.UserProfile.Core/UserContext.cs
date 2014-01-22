using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace College.UserProfile.Ux
{
    public static class UserContext
    {
        public static int CurrentUserID
        {
            get
            {
                return HttpContext.Current.Session["CurrentUserID"] != null ? Int32.Parse(HttpContext.Current.Session["CurrentUserID"].ToString()) : 0;
            }
            set
            {
                HttpContext.Current.Session["CurrentUserID"] = value.ToString();
            }
        }

        public static int CurrentUserLoginID
        {
            get
            {
                return HttpContext.Current.Session["CurrentUserLoginID"] != null ? Int32.Parse(HttpContext.Current.Session["CurrentUserLoginID"].ToString()) : 0;
            }
            set
            {
                HttpContext.Current.Session["CurrentUserLoginID"] = value.ToString();
            }
        }

        public static bool IsFaceBookUser
        {
            get
            {
                return HttpContext.Current.Session["IsFaceBookUser"] != null ? Boolean.Parse(HttpContext.Current.Session["IsFaceBookUser"].ToString()) : false;
            }
            set
            {
                HttpContext.Current.Session["IsFaceBookUser"] = value.ToString();
            }
        }
    }
}
