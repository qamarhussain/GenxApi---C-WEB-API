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
    
    public partial class Manuf_ProductionDetail
    {
        public int CompanyId { get; set; }
        public string InvItemId { get; set; }
        public string BatchId { get; set; }
        public string PhaseId { get; set; }
        public decimal Quantity { get; set; }
        public decimal BatchQuantity { get; set; }
        public string StepId { get; set; }
        public string ProductionId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string Createdby { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string ItemId { get; set; }
        public int id { get; set; }
        public Nullable<decimal> Price { get; set; }
        public int BusinessUnitId { get; set; }
    
        public virtual Manuf_Production Manuf_Production { get; set; }
    }
}
