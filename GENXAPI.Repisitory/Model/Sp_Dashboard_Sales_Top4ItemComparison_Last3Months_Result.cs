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
    
    public partial class Sp_Dashboard_Sales_Top4ItemComparison_Last3Months_Result
    {
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> BusinessUnitId { get; set; }
        public string ItemId { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Nullable<int> SalesMonth { get; set; }
        public Nullable<int> SalesYear { get; set; }
        public Nullable<int> CurrentDate { get; set; }
        public Nullable<System.DateTime> CurrentDateminus { get; set; }
        public string Category { get; set; }
        public string Sub_Category { get; set; }
        public string Item_Name { get; set; }
    }
}
