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
    
    public partial class Job
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Job()
        {
            this.JobChilds = new HashSet<JobChild>();
        }
    
        public int JobId { get; set; }
        public int TenderId { get; set; }
        public string TenderNo { get; set; }
        public byte JobStatus { get; set; }
        public string PONo { get; set; }
        public Nullable<System.DateTime> PODate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string PRNo { get; set; }
        public string ProposalRef { get; set; }
        public string Remarks { get; set; }
        public string OtherTermsConditions { get; set; }
        public string InvoiceAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public byte StatusId { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<int> LastModifiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> BusinessUnitId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobChild> JobChilds { get; set; }
        public virtual Tender Tender { get; set; }
    }
}