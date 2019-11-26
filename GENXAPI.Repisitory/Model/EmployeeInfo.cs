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
    
    public partial class EmployeeInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmployeeInfo()
        {
            this.EmployeeHistories = new HashSet<EmployeeHistory>();
            this.Registration_User = new HashSet<Registration_User>();
        }
    
        public int CompanyId { get; set; }
        public string EmployeeId { get; set; }
        public int BusinessUnitId { get; set; }
        public string EmployeeCategory { get; set; }
        public string EmployeeName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public System.DateTime JoiningDate { get; set; }
        public byte[] Image { get; set; }
        public string MobileNo { get; set; }
        public string EMail { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        public Nullable<int> MaritalStatusId { get; set; }
        public Nullable<int> GenderId { get; set; }
        public string CNIC { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Qualification { get; set; }
        public Nullable<int> JobExperienceId { get; set; }
        public Nullable<double> Salary { get; set; }
        public Nullable<bool> LoanStatus { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string FatherName { get; set; }
        public string Ref_Name { get; set; }
        public string Ref_FatherName { get; set; }
        public string Ref_Mobile { get; set; }
        public string Ref_CNIC { get; set; }
        public string Ref_Address { get; set; }
        public string Ref_Relationship { get; set; }
        public string Face { get; set; }
        public string FingerPrint { get; set; }
        public string Password { get; set; }
    
        public virtual CompanyInfo CompanyInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeHistory> EmployeeHistories { get; set; }
        public virtual EmployeeJobExperience EmployeeJobExperience { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual MaritalStatu MaritalStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration_User> Registration_User { get; set; }
    }
}
