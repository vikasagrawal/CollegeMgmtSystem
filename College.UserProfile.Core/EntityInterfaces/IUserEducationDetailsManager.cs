using College.UserProfile.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.EntityInterfaces
{
    public interface IUserEducationDetailsManager : IDisposable
    {
        List<UserEducationDetail> GetUserEducationDetails(int userId);
        void AddUpdateUserEducationDetails(int userId, List<UserEducationDetail> userEducationDetails);
    }
}
