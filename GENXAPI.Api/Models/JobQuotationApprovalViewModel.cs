using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GENXAPI.Api.Models
{
    public class JobQuotationApprovalViewModel
    {
        public JobQuotationApprovalViewModel()
        {
            vendorInfo = new List<JobQuotationApprovalViewModelVendors>();
        }
        public int VendorQUotationChildId { get; set; }
        public int VendorQuotationId { get; set; }
        public int? JobId { get; set; }
        public string JobNo { get; set; }
        public int VendorId { get; set; }
        public decimal Amount { get; set; }
        public string ItemCode { get; set; }
        public string Particulars { get; set; }
        public List<JobQuotationApprovalViewModelVendors> vendorInfo { get; set; }
    }

    public class JobQuotationApprovalViewModelVendors
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public decimal Amount { get; set; }
    }

}