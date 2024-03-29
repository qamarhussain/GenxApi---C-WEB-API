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
    
    public partial class AML_Units
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AML_Units()
        {
            this.AML_FleetService = new HashSet<AML_FleetService>();
            this.AML_ItemInformation = new HashSet<AML_ItemInformation>();
            this.AML_PickupOrderChild = new HashSet<AML_PickupOrderChild>();
        }
    
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Nullable<int> BusinessUnitId { get; set; }
        public string Title { get; set; }
        public string Abbreviation { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public Nullable<byte> StatusId { get; set; }
        public Nullable<int> Project { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AML_FleetService> AML_FleetService { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AML_ItemInformation> AML_ItemInformation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AML_PickupOrderChild> AML_PickupOrderChild { get; set; }
    }
}
