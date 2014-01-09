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
                if (string.IsNullOrEmpty(value.LanguagesSpoken))
                {
                    this.UserLanguages = new List<int>();
                }
                else
                {
                    this.UserLanguages = XElement.Parse(value.LanguagesSpoken).Elements("Language").Select(f => Int32.Parse(f.Value));
                    //this.UserLanguages = XElement.Parse(value.LanguagesSpoken).Elements("Language").Select(f => f.Value);
                }

            }
        }
        public IEnumerable<int> UserLanguages;
    }
}
