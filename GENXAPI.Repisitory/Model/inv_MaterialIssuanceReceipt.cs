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
    
    public partial class inv_MaterialIssuanceReceipt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public inv_MaterialIssuanceReceipt()
        {
            this.inv_MaterialIssuanceReceiptDetail = new HashSet<inv_MaterialIssuanceReceiptDetail>();
        }
    
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public string PdnId { get; set; }
        public string MirId { get; set; }
        public int DepartmentId { get; set; }
        public string PersonName { get; set; }
        public string MirStatus { get; set; }
        public System.DateTime MaterialIssuanceDate { get; set; }
        public Nullable<bool> InvoicePosted { get; set; }
        public string InvoiceId { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.Guid CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inv_MaterialIssuanceReceiptDetail> inv_MaterialIssuanceReceiptDetail { get; set; }
    }
}
