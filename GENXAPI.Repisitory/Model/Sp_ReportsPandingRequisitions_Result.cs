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
    
    public partial class Sp_ReportsPandingRequisitions_Result
    {
        public int BusinessUnitId { get; set; }
        public int CompanyId { get; set; }
        public string PdnId { get; set; }
        public int DepartmentId { get; set; }
        public string EmpolyeeId { get; set; }
        public System.DateTime ProjectionDate { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public int Priority { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.Guid CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<System.DateTime> ConfirmationDate { get; set; }
        public string PurchaseRecogzitionStatus { get; set; }
        public System.DateTime DemandNoteDate { get; set; }
    }
}
