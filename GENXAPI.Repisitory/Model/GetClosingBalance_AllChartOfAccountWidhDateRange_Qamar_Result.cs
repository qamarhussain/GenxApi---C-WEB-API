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
    
    public partial class GetClosingBalance_AllChartOfAccountWidhDateRange_Qamar_Result
    {
        public Nullable<int> HeadIndex { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> BusinessUnitId { get; set; }
        public string ChartAccount { get; set; }
        public string FirstHead { get; set; }
        public string SecondHead { get; set; }
        public string ThirdHead { get; set; }
        public string Title { get; set; }
        public Nullable<decimal> OpeningBalance { get; set; }
        public Nullable<decimal> CurrentBalance { get; set; }
        public Nullable<double> Debit { get; set; }
        public Nullable<double> Credit { get; set; }
    }
}
