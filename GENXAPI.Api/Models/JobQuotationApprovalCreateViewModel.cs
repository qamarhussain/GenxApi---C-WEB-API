using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GENXAPI.Api.Models
{
    public class JobQuotationApprovalCreateViewModel
    {
        public JobQuotationApprovalCreateViewModel()
        {
            listItemCodes = new List<JobQuotationApproval>();
        }

        public List<JobQuotationApproval> listItemCodes { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> ContractId { get; set; }
        public Nullable<int> JobId { get; set; }
        public string JobNo { get; set; }
    }

}