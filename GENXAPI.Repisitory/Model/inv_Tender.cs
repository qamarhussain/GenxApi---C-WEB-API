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
    
    public partial class inv_Tender
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public inv_Tender()
        {
            this.inv_TenderDetail = new HashSet<inv_TenderDetail>();
        }
    
        public int BusinessUnitId { get; set; }
        public int CompanyId { get; set; }
        public string RecogzitionId { get; set; }
        public string TenderId { get; set; }
        public string TenderSubject { get; set; }
        public string TenderStatus { get; set; }
        public Nullable<int> DaysToComplete { get; set; }
        public System.DateTime TenderDate { get; set; }
        public string CashOrCredit { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inv_TenderDetail> inv_TenderDetail { get; set; }
    }
}
