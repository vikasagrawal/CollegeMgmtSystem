//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace College.UserProfile.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class CollegeCourseReview
    {
        public int CollegeCourseReviewId { get; set; }
        public int UserId { get; set; }
        public System.DateTime ReviewDate { get; set; }
        public int CollegeCourseId { get; set; }
        public bool IsAnonymousUser { get; set; }
        public string NickName { get; set; }
        public string AvatarImage { get; set; }
        public bool IsCompleted { get; set; }
    }
}
