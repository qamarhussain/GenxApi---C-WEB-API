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
    
    public partial class inv_MaterialIssuanceReceiptDetail
    {
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public string PdnId { get; set; }
        public string MirId { get; set; }
        public int ItemSerialNumber { get; set; }
        public string ItemId { get; set; }
        public decimal ApprovedQuantity { get; set; }
        public decimal IssuedQuantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.Guid CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
    
        public virtual inv_MaterialIssuanceReceipt inv_MaterialIssuanceReceipt { get; set; }
    }
}