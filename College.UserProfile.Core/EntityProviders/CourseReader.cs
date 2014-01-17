﻿using College.UserProfile.Core.EntityInterfaces;
using College.UserProfile.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.EntityProviders
{
    public class CourseReader : ICourseReader, IDisposable
    {
        private UserProfilesContext _db;

        public CourseReader(UserProfilesContext db)
        {
            _db = db;
        }

        public IEnumerable<dynamic> GetCoursesForLookup()
        {
            var courses = from c1 in _db.Courses
                          orderby c1.CourseName
                          select new
                          {
                              LookupID = c1.CourseId,
                              LookupValue = c1.CourseName
                          };

            return courses;
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