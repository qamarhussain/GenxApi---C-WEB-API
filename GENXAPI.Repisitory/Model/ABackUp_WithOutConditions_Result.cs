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
    
    public partial class ABackUp_WithOutConditions_Result
    {
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> BusinessUnitId { get; set; }
        public string ChartAccount { get; set; }
        public string ChartAccountTitle { get; set; }
        public string AccountCode { get; set; }
        public string VocherId { get; set; }
        public string VocherType { get; set; }
        public Nullable<System.DateTime> VoucherDate { get; set; }
        public string Naration { get; set; }
        public Nullable<double> Dr_Amount { get; set; }
        public Nullable<double> Cr_Amount { get; set; }
        public Nullable<double> OpeningBalance { get; set; }
        public Nullable<double> Balance { get; set; }
        public Nullable<double> PreviousBalance { get; set; }
    }
}
