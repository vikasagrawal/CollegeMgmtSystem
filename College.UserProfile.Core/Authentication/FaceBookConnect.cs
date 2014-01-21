using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Specialized;

namespace College.UserProfile.Core.Authentication
{
    public static class FaceBookConnect
    {
        public readonly static string API_Key = Constants.FB_API_KEY;

        public readonly static string API_Secret = Constants.FB_Secret_Key;

        public static string AccessToken
        {
            get
            {
                return HttpContext.Current.Session["AccessToken"] != null ? HttpContext.Current.Session["AccessToken"].ToString() : string.Empty;
            }
            set
            {
                HttpContext.Current.Session["AccessToken"] = (object)value;
            }
        }

        public static string Fetch(string userId)
        {
            var facebookClient = new Facebook.FacebookClient();
            facebookClient.AccessToken = AccessToken;
            return facebookClient.Get(userId).ToString();
        }
    }
}