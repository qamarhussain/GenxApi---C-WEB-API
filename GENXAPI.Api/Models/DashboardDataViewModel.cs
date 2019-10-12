using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GENXAPI.Api.Models
{
    public class DashboardDataViewModel
    {
        public JobQuotationApproval jobQuotationApproval { get; set; }
        public Tender tender { get; set; }
        public TenderDetail tenderDetail { get; set; }
        public TenderChild tenderChild { get; set; }
    }
}