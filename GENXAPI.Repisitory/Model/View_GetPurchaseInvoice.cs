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
    
    public partial class View_GetPurchaseInvoice
    {
        public string VocherId { get; set; }
        public string VoucherType { get; set; }
        public string AccountTitle { get; set; }
        public string AccountCode { get; set; }
        public double Dr_Amount { get; set; }
        public double Cr_Amount { get; set; }
        public string Naration { get; set; }
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public System.DateTime VocherDate { get; set; }
        public string PaymentType { get; set; }
        public string Name { get; set; }
    }
}
