using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.EntityInterfaces
{
    public interface ISubjectReader : IDisposable
    {
        IEnumerable<dynamic> GetSubjectsForLookup();
    }
}
