using College.UserProfile.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace College.UserProfile.Core.Authentication
{
    public static class Utils
    {
        public static bool SetAuthenticationCookie(UserLogin userLogin)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
               1,                                     // ticket version
               userLogin.EmailAddress,                              // authenticated username
               DateTime.Now,                          // issueDate
               DateTime.Now.AddMinutes(30),           // expiryDate
               true,                          // true to persist across browser sessions
               userLogin.UserLoginID.ToString(),                              // can be used to store additional user data
               FormsAuthentication.FormsCookiePath);  // the path for the cookie

            // Encrypt the ticket using the machine key
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);

            // Add the cookie to the request to save it
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;

            HttpContext.Current.Response.Cookies.Add(cookie);

            // Your redirect logic
            //HttpContext.Current.Response.Redirect(FormsAuthentication.GetRedirectUrl(userLogin.EmailAddress, true));

            return true;
        }

        public static string GetAutheticatedUserData()
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            return ticket.UserData;
        }
    }
}
