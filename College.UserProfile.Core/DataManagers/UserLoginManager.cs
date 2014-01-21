using College.UserProfile.Core.DataManagerInterfaces;
using College.UserProfile.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.DataManagers
{
    public class UserLoginManager : IUserLoginManager, IDisposable
    {
        private UserProfilesContext _db;

        public UserLoginManager(UserProfilesContext db)
        {
            _db = db;
        }

        public bool IsUserLoginExists(string emailAddress)
        {
            return _db.UserLogins.Count(e => e.EmailAddress.Equals(emailAddress, StringComparison.OrdinalIgnoreCase)) > 0;
        }

        public Entities.UserLogin ValidateUserLogin(string emailAddress, string password)
        {
            return _db.UserLogins.SingleOrDefault(usr => usr.EmailAddress.Equals(emailAddress, StringComparison.OrdinalIgnoreCase)
                && usr.Password == password);
        }

        public Entities.UserLogin GetUserLogin(string emailAddress)
        {
            return _db.UserLogins.SingleOrDefault(usr => usr.EmailAddress.Equals(emailAddress, StringComparison.OrdinalIgnoreCase));
        }

        public Entities.UserLogin GetUserLogin(int userLoginID)
        {
            return _db.UserLogins.SingleOrDefault(usr => usr.UserLoginID == userLoginID);
        }

        public void AddUserLogin(UserLogin userLogin)
        {
            _db.UserLogins.Add(userLogin);
            _db.SaveChanges();
        }

        public bool VerifyAndUpdateUserEmail(int userLoginID, string verificationCode)
        {
            var userLogin = this.GetUserLogin(userLoginID);
            if (userLogin.IsEmailVerified == true || (userLogin.VerificationCode != null &&
                userLogin.VerificationCode.Equals(verificationCode, StringComparison.OrdinalIgnoreCase)))
            {
                userLogin.IsEmailVerified = true;
                _db.SaveChanges();
                return true;
            }

            return false;
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
