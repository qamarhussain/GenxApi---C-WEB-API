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
    
    public partial class AML_JobChild
    {
        public int Id { get; set; }
        public Nullable<int> JobId { get; set; }
        public string ItemCode { get; set; }
        public string DetailedDescription { get; set; }
        public string UnitOfMesure { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> UnitCost { get; set; }
        public Nullable<int> OfficeId { get; set; }
        public Nullable<byte> IsExecuted { get; set; }
    
        public virtual AML_Job AML_Job { get; set; }
        public virtual AML_RegionalOffice AML_RegionalOffice { get; set; }
    }
}
