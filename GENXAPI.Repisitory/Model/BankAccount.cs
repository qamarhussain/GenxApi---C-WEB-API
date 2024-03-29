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
    
    public partial class BankAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BankAccount()
        {
            this.BankAccountDetails = new HashSet<BankAccountDetail>();
        }
    
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public int BankAccountId { get; set; }
        public string ChartAccount { get; set; }
        public string BankName { get; set; }
        public string BranchCode { get; set; }
        public string AccountCode { get; set; }
        public string AccountType { get; set; }
        public string AccountTitle { get; set; }
        public string AccountOpeningDate { get; set; }
        public string AccountPersonName { get; set; }
        public double OpeningBalance { get; set; }
        public bool AccountStatus { get; set; }
        public string BankCity { get; set; }
        public string BankAddress { get; set; }
        public string BankPhone { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BankAccountDetail> BankAccountDetails { get; set; }
    }
}
