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
    
    public partial class View_inv_GetItemsInfoInWareHouseForMoveStock
    {
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public int WarehouseId { get; set; }
        public string ItemId { get; set; }
        public string BinCartId { get; set; }
        public Nullable<double> Quantity { get; set; }
        public string Room { get; set; }
        public string Rack { get; set; }
        public string Bin { get; set; }
    }
}
