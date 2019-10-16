using GENXAPI.Repisitory.Model;
using System.Collections.Generic;

namespace GENXAPI.Api.Models
{
    public class DashboardDataViewModel
    {
        public JobQuotationApproval JobQuotationApprovals { get; set; }
        public Tender Tenders { get; set; }
        public List<TenderDetail> TenderDetails { get; set; }
        public List<TenderChild> TenderChilds { get; set; }
    }
}