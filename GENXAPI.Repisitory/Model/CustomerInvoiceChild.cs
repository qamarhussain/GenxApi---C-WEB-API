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
    
    public partial class CustomerInvoiceChild
    {
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string JobOrderId { get; set; }
        public int TransctionId { get; set; }
        public int ChildId { get; set; }
        public Nullable<decimal> ReceivedAmount { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> ReceivedDate { get; set; }
        public string SecondChartAccount { get; set; }
        public string SecondChartAccountTitle { get; set; }
        public Nullable<decimal> WithHoldingTax { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
    
        public virtual CustomerInvoiceMasterDetail CustomerInvoiceMasterDetail { get; set; }
    }
}
