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
    
    public partial class DailyCashReceive
    {
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public int DCRId { get; set; }
        public System.DateTime PostDate { get; set; }
        public string Particulars { get; set; }
        public string Mode { get; set; }
        public decimal Amount { get; set; }
        public bool Approved { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
