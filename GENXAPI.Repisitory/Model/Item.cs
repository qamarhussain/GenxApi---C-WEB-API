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
    
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.ItemImages = new HashSet<ItemImage>();
            this.OrderDeliveryDetails = new HashSet<OrderDeliveryDetail>();
            this.OrderDetails = new HashSet<OrderDetail>();
            this.SalesReturnDetails = new HashSet<SalesReturnDetail>();
            this.Warehouses = new HashSet<Warehouse>();
        }
    
        public int CompanyId { get; set; }
        public string ItemId { get; set; }
        public string Name { get; set; }
        public Nullable<double> Height { get; set; }
        public Nullable<double> Width { get; set; }
        public Nullable<double> Length { get; set; }
        public double Weight { get; set; }
        public double Discount { get; set; }
        public Nullable<double> Density { get; set; }
        public string RatioMeasure { get; set; }
        public string UnitMeasure { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public Nullable<double> CostPrice { get; set; }
        public string AccountCode { get; set; }
        public Nullable<double> MaxStockLevel { get; set; }
        public Nullable<double> MinStockLevel { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public Nullable<int> SizeType { get; set; }
        public Nullable<double> cbm { get; set; }
        public string Description { get; set; }
        public string Packing { get; set; }
        public string SROcode { get; set; }
        public string HScode { get; set; }
        public string TDSNo { get; set; }
        public string CustomDuty { get; set; }
        public string SRO_Desc { get; set; }
        public string ArticleNo { get; set; }
        public string ForCustom { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemImage> ItemImages { get; set; }
        public virtual ItemsDefination ItemsDefination { get; set; }
        public virtual Ratio Ratio { get; set; }
        public virtual Unit Unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDeliveryDetail> OrderDeliveryDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesReturnDetail> SalesReturnDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
