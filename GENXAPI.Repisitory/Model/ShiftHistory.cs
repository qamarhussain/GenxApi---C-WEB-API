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
    
    public partial class ShiftHistory
    {
        public int EmployeeUid { get; set; }
        public string EmployeeId { get; set; }
        public int ShiftUid { get; set; }
        public int ShiftId { get; set; }
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public System.DateTime ShiftHistoryDate { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    
        public virtual ShiftInfo ShiftInfo { get; set; }
    }
}
