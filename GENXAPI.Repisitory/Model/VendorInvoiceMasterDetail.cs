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
    
    public partial class VendorInvoiceMasterDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VendorInvoiceMasterDetail()
        {
            this.VendorInvoiceChilds = new HashSet<VendorInvoiceChild>();
        }
    
        public string VendorName { get; set; }
        public string Narration { get; set; }
        public string ServiceType { get; set; }
        public decimal Amount { get; set; }
        public decimal GST { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string Createdby { get; set; }
        public Nullable<System.DateTime> LastModefiedDate { get; set; }
        public string LastModedfiedby { get; set; }
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public string VendorId { get; set; }
        public string DocumentRef { get; set; }
        public int TransctionId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendorInvoiceChild> VendorInvoiceChilds { get; set; }
        public virtual VendorInvoiceMaster VendorInvoiceMaster { get; set; }
    }
}
