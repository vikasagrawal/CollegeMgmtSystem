using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.DataReaderInterfaces
{
    public interface ICourseReader : IDisposable
    {
        IEnumerable<dynamic> GetCoursesForLookup();
    }
}
