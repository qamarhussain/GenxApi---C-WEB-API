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
    
    public partial class View_SalesTaxInvoice
    {
        public System.DateTime SaleInvoiceDate { get; set; }
        public Nullable<long> SalesTaxId { get; set; }
        public string Name { get; set; }
        public string NTN { get; set; }
        public double DeliveredQuantity { get; set; }
        public int CompanyId { get; set; }
        public double Price { get; set; }
        public Nullable<double> GST { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ComapnyName { get; set; }
        public string STRN { get; set; }
        public string Expr2 { get; set; }
        public string SaleInvoiceId { get; set; }
        public int BusinessUnitId { get; set; }
        public Nullable<bool> ReverseMethod { get; set; }
    }
}
