using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.DataManagerInterfaces
{
    public interface IUserProfileManager : IDisposable
    {
        Models.UserProfile GetUserProfile(int userLoginId);
        Models.UserProfile AddOrUpdateUserProfile(Models.UserProfile userProfile);

    }
}
