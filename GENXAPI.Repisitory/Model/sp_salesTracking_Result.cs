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
    
    public partial class sp_salesTracking_Result
    {
        public string OrderId { get; set; }
        public string DeliveryId { get; set; }
        public string SaleInvoiceId { get; set; }
        public string Name { get; set; }
        public string VocherId { get; set; }
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public System.DateTime BookingDate { get; set; }
        public Nullable<long> SalesTaxId { get; set; }
    }
}