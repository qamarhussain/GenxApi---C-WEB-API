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
    
    public partial class inv_Miniwarehouse
    {
        public int TransactionId { get; set; }
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public int DepartmentId { get; set; }
        public string ItemId { get; set; }
        public int SerialNo { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public double Credit { get; set; }
        public double Debit { get; set; }
        public string RecordReference { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public string PerformaInvoiceId { get; set; }
    }
}
