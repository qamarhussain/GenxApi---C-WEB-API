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
    
    public partial class Manuf_DefineRecipeMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manuf_DefineRecipeMaster()
        {
            this.Manuf_DefineRecipeDetail = new HashSet<Manuf_DefineRecipeDetail>();
        }
    
        public int CompanyId { get; set; }
        public string SalesItemId { get; set; }
        public string ProcedureId { get; set; }
        public string StepId { get; set; }
        public string PhaseId { get; set; }
        public string RecipeId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string Createdby { get; set; }
        public string LastModifiedby { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public int BusinessUnitId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Manuf_DefineRecipeDetail> Manuf_DefineRecipeDetail { get; set; }
    }
}
