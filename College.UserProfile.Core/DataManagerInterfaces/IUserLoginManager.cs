using College.UserProfile.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.DataManagerInterfaces
{
    public interface IUserLoginManager : IDisposable
    {
        bool IsUserLoginExists(string emailAddress);
        UserLogin ValidateUserLogin(string emailAddress, string password);
        UserLogin GetUserLogin(string emailAddress);
        UserLogin GetUserLogin(int userLoginID);
        void AddUserLogin(UserLogin userLogin);
    }
}
