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
    
    public partial class View_SaleReturnInvoiceDetail_Report
    {
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public string OrderId { get; set; }
        public string OrderType { get; set; }
        public string DeliveryId { get; set; }
        public string SalesReturnId { get; set; }
        public string SalesReturnInvoiceId { get; set; }
        public string ItemId { get; set; }
        public double ReturnedQuantity { get; set; }
        public Nullable<double> Price { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime SaleReturnInvoiceDate { get; set; }
    }
}
