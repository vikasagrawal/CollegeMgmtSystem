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
    
    public partial class CollegeCourseEligibility
    {
        public int CollegeCourseEligibilityId { get; set; }
        public int CollegeCourseId { get; set; }
        public int StudentCategoryId { get; set; }
        public decimal Percentage { get; set; }
    }
}