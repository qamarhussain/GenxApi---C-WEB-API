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
    
    public partial class Manuf_Production
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manuf_Production()
        {
            this.Manuf_ProductionDetail = new HashSet<Manuf_ProductionDetail>();
        }
    
        public int CompanyId { get; set; }
        public string ItemId { get; set; }
        public string BatchId { get; set; }
        public string ProcedureId { get; set; }
        public string StepId { get; set; }
        public string PhaseId { get; set; }
        public string ProductionId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string Createdby { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public string InvoiceId { get; set; }
        public Nullable<System.DateTime> PostedDate { get; set; }
        public string Method { get; set; }
        public int BusinessUnitId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Manuf_ProductionDetail> Manuf_ProductionDetail { get; set; }
    }
}
