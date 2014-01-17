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
        public User user
        {
            get;
            set;
        }
        public List<int> UserLanguages { get; set; }
        public List<int> UserFieldOfInterest { get; set; }

        public List<UserEducationDetail> UserEducationDetail { get; set; }
    }
}
