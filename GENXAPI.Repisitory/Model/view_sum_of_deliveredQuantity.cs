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
    
    public partial class view_sum_of_deliveredQuantity
    {
        public string OrderId { get; set; }
        public string ItemName { get; set; }
        public Nullable<double> AprovedQuantity { get; set; }
        public Nullable<double> DeliveredQuantity { get; set; }
        public int BusinessUnitId { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string ItemId { get; set; }
        public int CompanyId { get; set; }
        public string UnitMeasure { get; set; }
    }
}
