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
    
    public partial class TransferItemWareHouseAudit
    {
        public int Id { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<long> TransectionId { get; set; }
        public Nullable<int> WarehouseId { get; set; }
        public string ItemId { get; set; }
        public string BatchCode { get; set; }
        public string TransferAudit { get; set; }
        public Nullable<double> Debit { get; set; }
        public Nullable<double> Credit { get; set; }
        public string IssuedTo { get; set; }
        public Nullable<System.DateTime> LogCreatedDate { get; set; }
    }
}
