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
    
    public partial class AML_GodownRow
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AML_GodownRow()
        {
            this.AML_GodownRack = new HashSet<AML_GodownRack>();
        }
    
        public int GodownRowId { get; set; }
        public Nullable<int> GodwonId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AML_GodownRack> AML_GodownRack { get; set; }
        public virtual AML_Godwom AML_Godwom { get; set; }
    }
}
