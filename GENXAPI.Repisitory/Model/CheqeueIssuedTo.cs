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
    
    public partial class CheqeueIssuedTo
    {
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public int ChequeIssuedId { get; set; }
        public string ChequeNo { get; set; }
        public string ChartAccount { get; set; }
        public Nullable<System.DateTime> ChequeIssuedDate { get; set; }
        public string IssuedBy { get; set; }
        public string ChequeIssuedDescription { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    }
}
