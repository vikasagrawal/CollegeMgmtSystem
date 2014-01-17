﻿using College.UserProfile.Core.EntityInterfaces;
using College.UserProfile.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.EntityProviders
{
    public class SubjectReader : ISubjectReader, IDisposable
    {
        private UserProfilesContext _db;

        public SubjectReader(UserProfilesContext db)
        {
            _db = db;
        }

        public IEnumerable<dynamic> GetSubjectsForLookup()
        {
            var subjects = from c1 in _db.Subjects
                           orderby c1.SubjectDesc
                           select new
                           {
                               LookupID = c1.SubjectId,
                               LookupValue = c1.SubjectDesc
                           };

            return subjects;
        }

        void IDisposable.Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
        }
    }
}