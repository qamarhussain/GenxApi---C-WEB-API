using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GENXAPI.Api.Models
{
    public class VendorQuotationsViewModel
    {
        public VendorQuotationsViewModel()
        {
            vendorInfo = new List<VendorQuotationApprovalViewModelVendors>();
        }
        public int VendorQUotationChildId { get; set; }
        public int VendorQuotationId { get; set; }
        public int? TenderId { get; set; }
        public string TendorNo { get; set; }
        public int VendorId { get; set; }
        public decimal Amount { get; set; }
        public string ItemCode { get; set; }
        public string Particulars { get; set; }
        public List<VendorQuotationApprovalViewModelVendors> vendorInfo { get; set; }
    }

    public class VendorQuotationApprovalViewModelVendors
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public decimal Amount { get; set; }
    }

}
