//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Students.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mark
    {
        public int MarkId { get; set; }
        public string Subject { get; set; }
        public int Score { get; set; }
        public int StudentId { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
