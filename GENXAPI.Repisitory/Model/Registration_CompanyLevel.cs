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
    
    public partial class Registration_CompanyLevel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Registration_CompanyLevel()
        {
            this.Registration_BusinessUnitLevel = new HashSet<Registration_BusinessUnitLevel>();
        }
    
        public System.Guid Login { get; set; }
        public int CompanyId { get; set; }
        public bool Status { get; set; }
        public System.DateTime createdDate { get; set; }
        public Nullable<System.Guid> modifiedBy { get; set; }
        public Nullable<System.DateTime> modifiedDate { get; set; }
    
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration_BusinessUnitLevel> Registration_BusinessUnitLevel { get; set; }
        public virtual Registration_User Registration_User { get; set; }
    }
}
