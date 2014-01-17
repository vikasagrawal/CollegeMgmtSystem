using College.UserProfile.Core.EntityInterfaces;
using College.UserProfile.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.EntityProviders
{
    public class UserProfileManager : IUserProfileManager, IDisposable
    {
        IUserManager _userManager;
        IUserEducationDetailsManager _userEducationDetailsManager;
        public UserProfileManager(IUserManager userManager, IUserEducationDetailsManager userEducationDetailsManager)
        {
            _userManager = userManager;
            _userEducationDetailsManager = userEducationDetailsManager;
        }

        public Models.UserProfile GetUserProfile(int userLoginId)
        {
            var userProfile = new Models.UserProfile();
            var user = _userManager.GetUser(userLoginId);

            if (user != null)
            {
                userProfile.user = user;
                userProfile.UserEducationDetail = _userEducationDetailsManager.GetUserEducationDetails(user.UserID);
                userProfile.UserLanguages = Helper.XMLStringToList(userProfile.user.LanguagesSpoken, Constants.LanguagesElementName);
                userProfile.UserFieldOfInterest = Helper.XMLStringToList(userProfile.user.FieldOfInterest, Constants.FieldOfInterestsElementName);
            }
            else
            {
                userProfile.user = _userManager.GetNewUser(userLoginId);
                userProfile.UserEducationDetail = new List<UserEducationDetail>();
                userProfile.UserFieldOfInterest = new List<int>();
                userProfile.UserLanguages = new List<int>();
            }

            return userProfile;
        }

        public Models.UserProfile AddOrUpdateUserProfile(Models.UserProfile userProfile)
        {
            userProfile.user.LanguagesSpoken = Helper.ListToXMLString(userProfile.UserLanguages, Constants.LanguagesRootElementName, Constants.LanguagesElementName);
            userProfile.user.FieldOfInterest = Helper.ListToXMLString(userProfile.UserFieldOfInterest, Constants.FieldOfInterestsRootElementName, Constants.FieldOfInterestsElementName);

            Entities.User existingUser = _userManager.GetUser(userProfile.user.UserLoginID);

            if (existingUser == null)
            {
                _userManager.AddUser(userProfile.user);
            }
            else
            {
                _userManager.UpdateUser(existingUser, userProfile.user);
            }

            _userEducationDetailsManager.AddUpdateUserEducationDetails(userProfile.user.UserID, userProfile.UserEducationDetail);

            return userProfile;
        }

        public void Dispose()
        {
            if (_userManager != null)
            {
                _userManager.Dispose();
            }

            if (_userEducationDetailsManager != null)
            {
                _userEducationDetailsManager.Dispose();
            }

        }
    }
}
