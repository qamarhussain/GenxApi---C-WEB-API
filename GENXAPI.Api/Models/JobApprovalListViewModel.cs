using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GENXAPI.Api.Models
{
    public class JobApprovalListViewModel
    {
        public JobQuotationApproval jobQuotationApproval { get; set; }
        public Tender tender { get; set; }
    }
}