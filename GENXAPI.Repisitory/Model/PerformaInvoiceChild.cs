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
    
    public partial class PerformaInvoiceChild
    {
        public int CompanyId { get; set; }
        public string CustomerId { get; set; }
        public string PerformaInvoiceId { get; set; }
        public int BusinessUnitId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string Createdby { get; set; }
        public string LastModifiedby { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public int InquiryId { get; set; }
        public string SalesItemId { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
        public int Id { get; set; }
    
        public virtual PerformaInvoiceMaster PerformaInvoiceMaster { get; set; }
    }
}