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
    
    public partial class AML_ExecutedJob
    {
        public int Id { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> ContractId { get; set; }
        public Nullable<int> JobId { get; set; }
        public string JobNo { get; set; }
        public string ItemCode { get; set; }
        public string Transporter { get; set; }
        public string VehicleNo { get; set; }
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }
        public string SupportingRefNo { get; set; }
        public string EmployeeName { get; set; }
        public string CEOName { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> ExecutionDate { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public Nullable<int> LastModifiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public byte StatusId { get; set; }
        public string WayBillNumber { get; set; }
    
        public virtual AML_Customers AML_Customers { get; set; }
    }
}
