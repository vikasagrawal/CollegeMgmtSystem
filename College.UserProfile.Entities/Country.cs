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
    
    public partial class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
