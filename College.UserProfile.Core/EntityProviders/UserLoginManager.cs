﻿using College.UserProfile.Core.EntityInterfaces;
using College.UserProfile.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.EntityProviders
{
    public class UserLoginManager : IUserLoginManager, IDisposable
    {
        private UserProfilesContext _db;

        public UserLoginManager(UserProfilesContext db)
        {
            _db = db;
        }

        public bool IsUserLoginExists(string emailAddress)
        {
            return _db.UserLogins.Count(e => e.EmailAddress.Equals(emailAddress, StringComparison.OrdinalIgnoreCase)) > 0;
        }

        public Entities.UserLogin GetUserLogin(string emailAddress, string password)
        {
            return _db.UserLogins.SingleOrDefault(usr => usr.EmailAddress.Equals(emailAddress, StringComparison.OrdinalIgnoreCase)
                && usr.Password == password);
        }

        public void AddUserLogin(UserLogin userLogin)
        {
            _db.UserLogins.Add(userLogin);
            _db.SaveChanges();
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