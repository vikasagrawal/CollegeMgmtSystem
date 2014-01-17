using College.UserProfile.Core.EntityInterfaces;
using College.UserProfile.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.EntityProviders
{
    public class UserManager : IUserManager, IDisposable
    {
        UserProfilesContext _db;
        public UserManager(UserProfilesContext db)
        {
            _db = db;
        }

        public Entities.User GetUser(int userLoginID)
        {
            return _db.Users.SingleOrDefault(x => x.UserLoginID == userLoginID);
        }

        public Entities.User GetNewUser(int userLoginId)
        {
            return new Entities.User() { UserLoginID = userLoginId, UserID = 0 };
        }

        public void AddUser(User newUser)
        {
            _db.Users.Add(newUser);
            _db.SaveChanges();
        }

        public void UpdateUser(User oldUser, User newUser)
        {
            _db.Entry(oldUser).CurrentValues.SetValues(newUser);
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
