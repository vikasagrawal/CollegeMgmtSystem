using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace College.UserProfile.Ux.Controllers
{
    public class LocalizationController : Controller
    {
        //
        // GET: /Localization/
        public ActionResult GlobalResources()
        {
            string files = Request.QueryString["files"];
            string folder = "App_GlobalResources";

            Response.ContentType = "text/javascript";

            if (files == null || files.Length == 0)
            {
                throw new ArgumentException("Parameter 'files' was not provided in querystring.");
            }
            Dictionary<string, object> resources = new Dictionary<string, object>();

            foreach (string file in files.Split(','))
            {
                string className = files.Split('.')[0];

                //Open the resx xml file
                string filePath = Server.MapPath("~\\" + folder + "\\" + file);
                XmlDocument document = new XmlDocument();
                document.Load(filePath);

                XmlNodeList nodes = document.SelectNodes("//data");

                foreach (XmlNode node in nodes)
                {
                    XmlAttribute attr = node.Attributes["name"];

                    String resourceKey = attr.Value;
                    resources.Add(resourceKey, null);

                    resources[resourceKey] = HttpContext.GetGlobalResourceObject(className, resourceKey); //'Has to be full path to the .aspx page
                }

            }

            return Json(new { resources }, JsonRequestBehavior.AllowGet);
        }
    }
}