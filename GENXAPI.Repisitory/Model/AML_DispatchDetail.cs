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
    
    public partial class AML_DispatchDetail
    {
        public int DispatchDetailId { get; set; }
        public Nullable<int> DispatchId { get; set; }
        public string ItemId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Location { get; set; }
        public string BatchNo { get; set; }
        public string PalletNo { get; set; }
    
        public virtual AML_Dispatch AML_Dispatch { get; set; }
        public virtual AML_ItemInformation AML_ItemInformation { get; set; }
    }
}