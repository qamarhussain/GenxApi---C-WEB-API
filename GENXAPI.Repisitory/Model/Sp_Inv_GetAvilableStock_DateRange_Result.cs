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
    
    public partial class Sp_Inv_GetAvilableStock_DateRange_Result
    {
        public string ItemId { get; set; }
        public Nullable<decimal> PrevousBalance { get; set; }
        public Nullable<decimal> CurrentBalance { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public double MinStockLevel { get; set; }
        public double MaxStockLevel { get; set; }
        public int CompanyId { get; set; }
    }
}