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
    
    public partial class inv_PurchaseReturn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public inv_PurchaseReturn()
        {
            this.inv_PurchaseReturnItemDetail = new HashSet<inv_PurchaseReturnItemDetail>();
        }
    
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public string PurchaseReturnId { get; set; }
        public System.DateTime PurchaseReturnDate { get; set; }
        public string PurchaseOrderId { get; set; }
        public string GatePasId { get; set; }
        public Nullable<int> VendorId { get; set; }
        public string TenderId { get; set; }
        public string RecogzitionId { get; set; }
        public string QuotationId { get; set; }
        public string VendorReference { get; set; }
        public Nullable<bool> InvoiceGenerated { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inv_PurchaseReturnItemDetail> inv_PurchaseReturnItemDetail { get; set; }
    }
}
