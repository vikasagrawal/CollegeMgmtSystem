using College.UserProfile.Core.DataReaderInterfaces;
using College.UserProfile.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.DataReaders
{
    public class UserShortListedCollegesReader : IUserShortListedCollegesReader, IDisposable
    {
        private UserProfilesContext _db;

        public UserShortListedCollegesReader(UserProfilesContext db)
        {
            _db = db;
        }

        public List<int> GetUserShortListedColleges(int UserID)
        {
            var shortListedColleges = from colleges in _db.UserShortlistedColleges
                                      where colleges.UserId == UserID
                                      select colleges.CollegeId;

            return shortListedColleges.ToList();
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
