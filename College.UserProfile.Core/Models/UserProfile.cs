using College.UserProfile.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace College.UserProfile.Core.Models
{
    public class UserProfile
    {
        private User _user;
        public User user
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                this.UserLanguages = Helper.XMLStringToList(value.LanguagesSpoken, Constants.LanguagesElementName);
            }
        }
        public List<int> UserLanguages { get; set; }
    }
}
