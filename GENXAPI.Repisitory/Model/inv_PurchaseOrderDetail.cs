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
    
    public partial class inv_PurchaseOrderDetail
    {
        public int BusinessUnitId { get; set; }
        public int CompanyId { get; set; }
        public string PurchaseOrderId { get; set; }
        public string ItemId { get; set; }
        public string RecogzitionId { get; set; }
        public string TenderId { get; set; }
        public string QuotationId { get; set; }
        public int VendorId { get; set; }
        public decimal ItemQuantity { get; set; }
        public decimal ItemPrice { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
    
        public virtual inv_ItemDetail inv_ItemDetail { get; set; }
        public virtual inv_PurchaseOrder inv_PurchaseOrder { get; set; }
        public virtual inv_Vendors inv_Vendors { get; set; }
    }
}
