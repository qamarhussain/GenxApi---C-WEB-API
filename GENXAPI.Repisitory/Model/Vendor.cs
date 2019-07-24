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
    
    public partial class Vendor
    {
        public int CompanyId { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string VendorType { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Phone { get; set; }
        public string FaxNo { get; set; }
        public string CNIC { get; set; }
        public string AccountNo { get; set; }
        public string NTN { get; set; }
        public string STRN { get; set; }
        public int CurrencyId { get; set; }
        public Nullable<int> NatureOfBusinessId { get; set; }
        public Nullable<int> TypeOfBusinessId { get; set; }
        public Nullable<int> YearEstablished { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Remarks { get; set; }
        public string AccountCode { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<bool> CopyStatus { get; set; }
        public Nullable<byte> StatusId { get; set; }
    }
}
