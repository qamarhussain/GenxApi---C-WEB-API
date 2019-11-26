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
    
    public partial class inv_CurrencyDefination
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public inv_CurrencyDefination()
        {
            this.InvLatterOfCredits = new HashSet<InvLatterOfCredit>();
            this.InvLetterOfCreditDetails = new HashSet<InvLetterOfCreditDetail>();
        }
    
        public int cId { get; set; }
        public int CompanyId { get; set; }
        public Nullable<double> currencyRate { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<int> LastModifiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvLatterOfCredit> InvLatterOfCredits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvLetterOfCreditDetail> InvLetterOfCreditDetails { get; set; }
    }
}