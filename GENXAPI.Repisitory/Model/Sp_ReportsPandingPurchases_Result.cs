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
    
    public partial class Sp_ReportsPandingPurchases_Result
    {
        public int BusinessUnitId { get; set; }
        public int CompanyId { get; set; }
        public string PurchaseOrderId { get; set; }
        public string RecogzitionId { get; set; }
        public string TenderId { get; set; }
        public string QuotationId { get; set; }
        public int VendorId { get; set; }
        public string PurchaseOrderStatus { get; set; }
        public System.DateTime PurchaseOrderDate { get; set; }
        public string Remarks { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<double> GST { get; set; }
        public Nullable<double> ExtraGST { get; set; }
    }
}
