using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.DataManagerInterfaces
{
    public interface IUserShortListedCollegesManager
    {
        void AddOrUpdate(int userID, List<int> userShortListedColleges);
    }
}
