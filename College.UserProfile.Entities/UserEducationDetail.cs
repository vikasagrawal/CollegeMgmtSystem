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
    
    public partial class UserEducationDetail
    {
        public int UserEducationDetailId { get; set; }
        public int UserId { get; set; }
        public int CollegeId { get; set; }
        public string PassingYear { get; set; }
        public int DegreeTypeId { get; set; }
        public int CourseId { get; set; }
        public int SubjectId { get; set; }
        public int InstituitionTypeId { get; set; }
        public string SchoolName { get; set; }
    }
}
