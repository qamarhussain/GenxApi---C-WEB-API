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
    
    public partial class View_PhaseStatusWithName
    {
        public int CompanyId { get; set; }
        public string ItemId { get; set; }
        public string PhaseName { get; set; }
        public string PhaseId { get; set; }
        public string StepId { get; set; }
        public bool Status { get; set; }
        public Nullable<System.DateTime> PhaseStart { get; set; }
        public Nullable<System.DateTime> PhaseEnd { get; set; }
        public string BatchId { get; set; }
    }
}
