using System.Web.Mvc;

namespace College.UserProfile.Ux.Areas.CodeLookup
{
    public class CodeLookupAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CodeLookup";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CodeLookup_default",
                "CodeLookup/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}