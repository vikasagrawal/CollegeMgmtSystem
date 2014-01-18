using College.UserProfile.Core.DataManagerInterfaces;
using College.UserProfile.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.DataManagers
{
    public class UserEducationDetailsManager : IUserEducationDetailsManager, IDisposable
    {
        UserProfilesContext _db;
        public UserEducationDetailsManager(UserProfilesContext db)
        {
            _db = db;
        }

        public void AddUpdateUserEducationDetails(int userId, List<UserEducationDetail> userEducationDetails)
        {
            var ed = from ued in _db.UserEducationDetails
                     where ued.UserId == userId
                     orderby ued.UserEducationDetailId
                     select ued;

            if (ed.Count() > 0)
            {
                _db.UserEducationDetails.RemoveRange(ed);
            }

            if (userEducationDetails != null)
            {
                foreach (var newued in userEducationDetails)
                {
                    newued.UserId = userId;
                    _db.UserEducationDetails.Add(newued);
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

        List<UserEducationDetail> IUserEducationDetailsManager.GetUserEducationDetails(int userId)
        {
            return _db.UserEducationDetails.Where(x => x.UserId == userId).ToList<UserEducationDetail>();
        }
    }
}
