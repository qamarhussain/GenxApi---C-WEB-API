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
    
    public partial class AML_GodwomType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AML_GodwomType()
        {
            this.AML_Godwom = new HashSet<AML_Godwom>();
        }
    
        public int GodwomTypeId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> BusinessUnitId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AML_Godwom> AML_Godwom { get; set; }
    }
}
