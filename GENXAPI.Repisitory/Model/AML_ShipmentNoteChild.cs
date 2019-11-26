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
    
    public partial class AML_ShipmentNoteChild
    {
        public int ShipmentNoteChildId { get; set; }
        public Nullable<int> ShipmentNoteId { get; set; }
        public string ItemInformationId { get; set; }
        public Nullable<int> GodownShelfId { get; set; }
        public string PalletNo { get; set; }
        public string Batch { get; set; }
        public string Status { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityOut { get; set; }
        public Nullable<decimal> NoOfBoxes { get; set; }
        public string Location { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<System.DateTime> MfgDate { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> GodownId { get; set; }
    
        public virtual AML_GodownShelf AML_GodownShelf { get; set; }
        public virtual AML_ItemInformation AML_ItemInformation { get; set; }
        public virtual AML_ShipmentNote AML_ShipmentNote { get; set; }
    }
}
