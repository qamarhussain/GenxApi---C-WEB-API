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
    
    public partial class InquiryMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InquiryMaster()
        {
            this.InquiryDetails = new HashSet<InquiryDetail>();
        }
    
        public int CompanyId { get; set; }
        public string CustomerId { get; set; }
        public int InquiryId { get; set; }
        public int BusinessUnitId { get; set; }
        public System.DateTime InquiryDate { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string Createdby { get; set; }
        public string LastModifiedby { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string InquiryRef { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InquiryDetail> InquiryDetails { get; set; }
    }
}
