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
    
    public partial class MachineFormula
    {
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public int MachineFormulaId { get; set; }
        public int MachineId { get; set; }
        public string ItemId { get; set; }
        public double StrockPerHour { get; set; }
        public double PcsPerStrok { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
