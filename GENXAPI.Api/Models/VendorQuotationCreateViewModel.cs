using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GENXAPI.Api.Models
{
    public class VendorQuotationCreateViewModel
    {
        public VendorQuotationCreateViewModel()
        {
            vendorQuotationChild = new List<VendorQuotationChild>();
        }
        public int VendorQuotationId { get; set; }
        public int BusinessUnitId { get; set; }
        public int CompanyId { get; set; }
        public int VendorId { get; set; }
        public Nullable<int> JobId { get; set; }
        public string JobNo { get; set; }
        public int TenderId { get; set; }
        public Nullable<byte> StatusId { get; set; }
        public string LastModifiedBy { get; set; }
        public string CreatedBy { get; set; }

        public List<VendorQuotationChild> vendorQuotationChild { get; set; }
    }
}