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
    
    public partial class VendorQuotationDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VendorQuotationDetail()
        {
            this.VendorQuotationChilds = new HashSet<VendorQuotationChild>();
        }
    
        public int VendorQuotationDetailId { get; set; }
        public int VendorQuotationId { get; set; }
        public int VendorId { get; set; }
        public string ItemCode { get; set; }
        public Nullable<int> DestinationToId { get; set; }
        public string DestinationToName { get; set; }
        public Nullable<int> DestinationFromId { get; set; }
        public string DestinationFromName { get; set; }
        public Nullable<decimal> Amount { get; set; }
    
        public virtual VendorQuotation VendorQuotation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendorQuotationChild> VendorQuotationChilds { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
