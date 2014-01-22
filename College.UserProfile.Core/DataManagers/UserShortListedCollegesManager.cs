using College.UserProfile.Core.DataManagerInterfaces;
using College.UserProfile.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.DataManagers
{
    public class UserShortListedCollegesManager : IUserShortListedCollegesManager, IDisposable
    {
        UserProfilesContext _db;
        public UserShortListedCollegesManager(UserProfilesContext db)
        {
            _db = db;
        }


        public void AddOrUpdate(int userID, List<int> userShortListedColleges)
        {
            var colleges = from uslc in _db.UserShortlistedColleges
                           where uslc.UserId == userID
                           select uslc;

            if (colleges.Count() > 0)
            {
                _db.UserShortlistedColleges.RemoveRange(colleges);
            }

            if (userShortListedColleges != null)
            {
                foreach (int collegeID in userShortListedColleges)
                {
                    var newuslc = new UserShortlistedCollege()
                    {
                        CollegeId = collegeID,
                        UserId = userID
                    };
                    _db.UserShortlistedColleges.Add(newuslc);
                }
            }

            _db.SaveChanges();
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
        }
    }
}
