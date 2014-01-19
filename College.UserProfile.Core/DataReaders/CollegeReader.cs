using College.UserProfile.Core.DataReaderInterfaces;
using College.UserProfile.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.DataReaders
{
    public class CollegeReader : ICollegeReader, IDisposable
    {
        private UserProfilesContext _db;

        public CollegeReader(UserProfilesContext db)
        {
            _db = db;
        }

        public IEnumerable<dynamic> GetCollegesForLookup()
        {
            var colleges = from c1 in _db.Colleges
                          orderby c1.CollegeName
                          select new
                          {
                              LookupID = c1.CollegeId,
                              LookupValue = c1.CollegeName
                          };

            return colleges;
        }


        public IEnumerable<dynamic> GetAvailableColleges(List<int> courseFields)
        {
            var colleges = from c1 in _db.Colleges
                           orderby c1.CollegeName
                           select c1;

            return colleges;
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
