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
    
    public partial class CollegeCourseQuestionAnswer
    {
        public int CollegeCourseQuestionAnswerId { get; set; }
        public int CollegeCourseQuestionId { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public string Action { get; set; }
    }
}
