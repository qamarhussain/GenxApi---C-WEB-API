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
    
    public partial class VendorQuotationChild
    {
        public int VendorQuotationChildId { get; set; }
        public int VendorQuotationId { get; set; }
        public string ItemCode { get; set; }
        public decimal Amount { get; set; }
    
        public virtual VendorQuotation VendorQuotation { get; set; }
    }
}
