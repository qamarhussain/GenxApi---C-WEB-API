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
    
    public partial class CustomerWiseCostingChild
    {
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public string InvItemId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public int InquiryId { get; set; }
        public string CreatedBy { get; set; }
        public string LastModefiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> LastModefiedDate { get; set; }
    }
}
