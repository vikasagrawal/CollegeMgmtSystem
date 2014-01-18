using College.UserProfile.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.DataManagerInterfaces
{
    public interface IUserManager : IDisposable
    {
        User GetUser(int UserLoginID);
        User GetNewUser(int userLoginId);
        void AddUser(User newUser);
        void UpdateUser(User oldUser, User newUser);
    }
}
