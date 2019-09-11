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
    
    public partial class Tender
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tender()
        {
            this.ContractCancelations = new HashSet<ContractCancelation>();
            this.Jobs = new HashSet<Job>();
            this.VendorQuotations = new HashSet<VendorQuotation>();
            this.TenderChilds = new HashSet<TenderChild>();
            this.TenderDetails = new HashSet<TenderDetail>();
        }
    
        public int Id { get; set; }
        public Nullable<int> BusinessUnitId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string TenderReference { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public System.DateTime IssuanceDate { get; set; }
        public string TenderSource { get; set; }
        public string TenderTerm { get; set; }
        public string TenderNo { get; set; }
        public Nullable<byte> StatusId { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<byte> ProceedStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractCancelation> ContractCancelations { get; set; }
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Job> Jobs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendorQuotation> VendorQuotations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TenderChild> TenderChilds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TenderDetail> TenderDetails { get; set; }
    }
}
