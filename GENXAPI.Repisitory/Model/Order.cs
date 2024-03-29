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
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.DispatchPlanDetails = new HashSet<DispatchPlanDetail>();
            this.OrderDeliveries = new HashSet<OrderDelivery>();
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public string OrderType { get; set; }
        public string OrderId { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime BookingDate { get; set; }
        public string PurchaseOrderNo { get; set; }
        public Nullable<System.DateTime> PurchaseOrderDate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public Nullable<System.DateTime> ConfirmationDate { get; set; }
        public Nullable<System.DateTime> WorkOrderDate { get; set; }
        public string Status { get; set; }
        public double SumCBM { get; set; }
        public string LastModifiedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public Nullable<double> GST { get; set; }
        public Nullable<double> AdditionalTax { get; set; }
        public string SalePerson { get; set; }
        public string OrderInstruction { get; set; }
        public string PaymentTerm { get; set; }
        public string PaymentType { get; set; }
        public Nullable<bool> ReverseMethod { get; set; }
        public Nullable<double> FurtherTax { get; set; }
        public Nullable<decimal> With_holding_tax { get; set; }
    
        public virtual BusinessUnit BusinessUnit { get; set; }
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DispatchPlanDetail> DispatchPlanDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDelivery> OrderDeliveries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual OrderStatusCurrent OrderStatusCurrent { get; set; }
    }
}
