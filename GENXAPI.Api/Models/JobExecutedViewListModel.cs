using GENXAPI.Repisitory.Model;
using System.Collections.Generic;

namespace GENXAPI.Api.Models
{
    public class JobExecutedViewListModel
    {
        public ExecutedJob executedJob { get; set; }
        public Tender tender { get; set; }
        public JobQuotationApproval jobQuotationApproval { get; set; }
        public List<TenderDetail> TenderDetails { get; set; }
        public List<TenderChild> TenderChilds { get; set; }
    }
}