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
    
    public partial class TenderChild
    {
        public int Id { get; set; }
        public string ItemCode { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public int TenderId { get; set; }
        public Nullable<int> VehicleId { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<int> FleetServiceId { get; set; }
        public Nullable<int> TenderDetailId { get; set; }
    
        public virtual FleetService FleetService { get; set; }
        public virtual Tender Tender { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual TenderDetail TenderDetail { get; set; }
    }
}
