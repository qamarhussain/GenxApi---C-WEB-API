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
    
    public partial class SP_Inv_TotalPurchase_Result
    {
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> BusinessUnitId { get; set; }
        public string GrnId { get; set; }
        public string PurchaseOrderId { get; set; }
        public string InvoiceId { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Vendor_Name { get; set; }
        public string Unit_Measure { get; set; }
        public string Item_Name { get; set; }
        public Nullable<decimal> GST { get; set; }
        public Nullable<decimal> Extra_Gst { get; set; }
    }
}
