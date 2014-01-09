using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace College.UserProfile.Core
{
    public static class Helper
    {
        public static string ListToXMLString(List<int> list, string rootElementName, string elementName)
        {
            if (list == null)
                return string.Empty;

            XElement el = new XElement(rootElementName, list.Select(kv => new XElement(elementName, kv)));
            return el.ToString();
        }

        public static List<int> XMLStringToList(string xmlString, string elementName)
        {
            if (string.IsNullOrEmpty(xmlString))
            {
                return new List<int>();
            }
            else
            {
                return XElement.Parse(xmlString).Elements(elementName).Select(f => Int32.Parse(f.Value)).ToList<int>();
            }
        }
    }
}
