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
    
    public partial class VendorQuotation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VendorQuotation()
        {
            this.VendorQuotationChilds = new HashSet<VendorQuotationChild>();
            this.VendorQuotationDetails = new HashSet<VendorQuotationDetail>();
        }
    
        public int VendorQuotationId { get; set; }
        public int BusinessUnitId { get; set; }
        public int CompanyId { get; set; }
        public int VendorId { get; set; }
        public int TenderId { get; set; }
        public Nullable<int> JobId { get; set; }
        public string JobNo { get; set; }
        public Nullable<byte> StatusId { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    
        public virtual Tender Tender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendorQuotationChild> VendorQuotationChilds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendorQuotationDetail> VendorQuotationDetails { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
