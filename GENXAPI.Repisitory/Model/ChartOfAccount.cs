//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GENXAPI.Repisitory.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChartOfAccount
    {
        public Nullable<int> HeadIndex { get; set; }
        public string ChartAccount { get; set; }
        public int CompanyId { get; set; }
        public string FYearTitle { get; set; }
        public string Title { get; set; }
        public string AccountType { get; set; }
        public double OpeningBalance { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<int> AccountTypeId { get; set; }
        public string Alias { get; set; }
    }
}
