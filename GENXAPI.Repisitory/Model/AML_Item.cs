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
    
    public partial class AML_Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AML_Item()
        {
            this.AML_ItemInformation = new HashSet<AML_ItemInformation>();
        }
    
        public string ItemId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> BusinessUnitId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<int> LastModifiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public byte StatusId { get; set; }
    
        public virtual AML_Customers AML_Customers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AML_ItemInformation> AML_ItemInformation { get; set; }
    }
}
