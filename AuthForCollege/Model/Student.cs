//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuthForCollege.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int IdStudent { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public System.DateTime BitthDate { get; set; }
        public int GenderId { get; set; }
        public int GroupId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> Height { get; set; }
        public Nullable<int> Weight { get; set; }
        public string Info { get; set; }
        public int StatusId { get; set; }
    
        public virtual Gender Gender { get; set; }
        public virtual Group Group { get; set; }
        public virtual StatusStudent StatusStudent { get; set; }
        public virtual User User { get; set; }
    }
}
