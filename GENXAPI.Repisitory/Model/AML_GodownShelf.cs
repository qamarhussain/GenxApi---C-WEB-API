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
    
    public partial class AML_GodownShelf
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AML_GodownShelf()
        {
            this.AML_ShipmentNoteChild = new HashSet<AML_ShipmentNoteChild>();
        }
    
        public int GodownShelfId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public Nullable<int> GodownRackId { get; set; }
        public Nullable<int> WarehouseId { get; set; }
        public Nullable<int> GodwomId { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
    
        public virtual AML_GodownRack AML_GodownRack { get; set; }
        public virtual AML_Godwom AML_Godwom { get; set; }
        public virtual AML_Warehouse AML_Warehouse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AML_ShipmentNoteChild> AML_ShipmentNoteChild { get; set; }
    }
}
