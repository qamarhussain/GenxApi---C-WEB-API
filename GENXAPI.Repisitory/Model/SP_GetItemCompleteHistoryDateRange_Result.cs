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
    
    public partial class SP_GetItemCompleteHistoryDateRange_Result
    {
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public int WareHouseId { get; set; }
        public string ReferenceId { get; set; }
        public string ItemId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Price { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.Guid CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
    }
}
