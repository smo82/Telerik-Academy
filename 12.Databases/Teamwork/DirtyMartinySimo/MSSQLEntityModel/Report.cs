//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MSSQLEntityModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Report
    {
        public Report()
        {
            this.ReportDetails = new HashSet<ReportDetail>();
        }
    
        public int ReportId { get; set; }
        public System.DateTime ReportDate { get; set; }
        public int SupermarketId { get; set; }
    
        public virtual ICollection<ReportDetail> ReportDetails { get; set; }
        public virtual Supermarket Supermarket { get; set; }
    }
}