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
    
    public partial class CompanyInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompanyInfo()
        {
            this.Attendances = new HashSet<Attendance>();
            this.BusinessUnitsInfoes = new HashSet<BusinessUnitsInfo>();
            this.Departments = new HashSet<Department>();
            this.Designations = new HashSet<Designation>();
            this.EmployeeInfoes = new HashSet<EmployeeInfo>();
            this.EmployeeTypes = new HashSet<EmployeeType>();
            this.Inv_ItemsDefination = new HashSet<Inv_ItemsDefination>();
            this.InvExpenseDefinations = new HashSet<InvExpenseDefination>();
            this.LetterOfCreditTypes = new HashSet<LetterOfCreditType>();
        }
    
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string NTN { get; set; }
        public string STRN { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public double GST { get; set; }
        public byte[] Logo { get; set; }
        public bool ShowName { get; set; }
        public bool ShowLogo { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendance> Attendances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BusinessUnitsInfo> BusinessUnitsInfoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Department> Departments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Designation> Designations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeInfo> EmployeeInfoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeType> EmployeeTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inv_ItemsDefination> Inv_ItemsDefination { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvExpenseDefination> InvExpenseDefinations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LetterOfCreditType> LetterOfCreditTypes { get; set; }
    }
}
