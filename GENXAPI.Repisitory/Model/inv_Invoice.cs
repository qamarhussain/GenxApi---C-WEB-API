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
    
    public partial class inv_Invoice
    {
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public string GrnId { get; set; }
        public string PurchaseOrderId { get; set; }
        public string InvoiceId { get; set; }
        public System.DateTime InvoiceDate { get; set; }
        public double FreightExpense { get; set; }
        public double LoadingUnLoadingExpense { get; set; }
        public double PackingExpense { get; set; }
        public double TollExpense { get; set; }
        public double SlittingCharges { get; set; }
        public double CuttingCharges { get; set; }
        public double LabourCharges { get; set; }
        public double BendingChanelling { get; set; }
        public double OtherExpense { get; set; }
        public bool ExpensesCash { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}