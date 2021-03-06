﻿using College.UserProfile.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.DataReaderInterfaces
{
    public interface ICollegeReader : IDisposable
    {
        IEnumerable<dynamic> GetCollegesForLookup();
        IEnumerable<dynamic> GetAvailableColleges(List<int> courseFields);
    }
}
