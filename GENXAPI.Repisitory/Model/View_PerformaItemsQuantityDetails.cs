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
    
    public partial class View_PerformaItemsQuantityDetails
    {
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public int CustomerId { get; set; }
        public int RecipeId { get; set; }
        public int InquiryId { get; set; }
        public string SalesItemId { get; set; }
        public string InvItemId { get; set; }
        public decimal Quantity { get; set; }
        public decimal InvItemQuantity { get; set; }
        public string ItemName { get; set; }
        public string UnitMeasure { get; set; }
        public Nullable<double> ItemWeight { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Brand { get; set; }
    }
}
