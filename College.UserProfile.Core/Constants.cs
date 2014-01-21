using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace College.UserProfile.Core
{
    public static class Constants
    {
        public const string LanguagesRootElementName = "Languages";
        public const string LanguagesElementName = "Language";
        public const string FieldOfInterestsRootElementName = "FieldOfInterests";
        public const string FieldOfInterestsElementName = "FieldOfInterest";
        public static readonly string FB_API_KEY = WebConfigurationManager.AppSettings["FacebookAPIKey"];
        public static readonly string FB_Secret_Key = WebConfigurationManager.AppSettings["FacebookSecretKey"];
        public static readonly string FaceBookPictureURLFormat = "https://graph.facebook.com/{0}/picture?width=100&height=100";

    }
}
