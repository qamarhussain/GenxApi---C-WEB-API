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
    
    public partial class sp_reports_Cursor_AvailableStock_New3_Mul_Result
    {
        public string itemId { get; set; }
        public string categoryId { get; set; }
        public string subCategoryId { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> MinStockLevel { get; set; }
        public Nullable<double> MaxStockLevel { get; set; }
        public Nullable<double> PreBalance { get; set; }
        public Nullable<double> CurrentBalance { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public int CompanyId1 { get; set; }
    }
}