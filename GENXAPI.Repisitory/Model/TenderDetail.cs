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
    
    public partial class TenderDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TenderDetail()
        {
            this.TenderChilds = new HashSet<TenderChild>();
        }
    
        public int Id { get; set; }
        public int TenderId { get; set; }
        public int CustomerId { get; set; }
        public Nullable<int> DestinationToId { get; set; }
        public Nullable<int> DestinationFromId { get; set; }
        public string ItemCode { get; set; }
        public int ProvinceId { get; set; }
        public Nullable<int> RegionId { get; set; }
        public string DestinationToName { get; set; }
        public string DestinationFromName { get; set; }
        public string ProvinceName { get; set; }
        public Nullable<byte> IsDeleted { get; set; }
    
        public virtual City City { get; set; }
        public virtual City City1 { get; set; }
        public virtual Province Province { get; set; }
        public virtual Region Region { get; set; }
        public virtual Tender Tender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TenderChild> TenderChilds { get; set; }
    }
}
