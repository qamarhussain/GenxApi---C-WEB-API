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
    
    public partial class AML_City
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AML_City()
        {
            this.AML_Customers = new HashSet<AML_Customers>();
            this.AML_PickupOrder = new HashSet<AML_PickupOrder>();
            this.AML_RegionalOffice = new HashSet<AML_RegionalOffice>();
            this.AML_TenderDetail = new HashSet<AML_TenderDetail>();
            this.AML_TenderDetail1 = new HashSet<AML_TenderDetail>();
            this.AML_Vendor = new HashSet<AML_Vendor>();
            this.AML_VendorQuotationChild = new HashSet<AML_VendorQuotationChild>();
            this.AML_VendorQuotationChild1 = new HashSet<AML_VendorQuotationChild>();
        }
    
        public int CityId { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
        public Nullable<byte> StatusId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public int RegionId { get; set; }
    
        public virtual AML_Region AML_Region { get; set; }
        public virtual AML_Province AML_Province { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AML_Customers> AML_Customers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AML_PickupOrder> AML_PickupOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AML_RegionalOffice> AML_RegionalOffice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AML_TenderDetail> AML_TenderDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AML_TenderDetail> AML_TenderDetail1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AML_Vendor> AML_Vendor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AML_VendorQuotationChild> AML_VendorQuotationChild { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AML_VendorQuotationChild> AML_VendorQuotationChild1 { get; set; }
    }
}
