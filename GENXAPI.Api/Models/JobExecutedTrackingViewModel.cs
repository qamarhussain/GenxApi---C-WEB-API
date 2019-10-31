using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GENXAPI.Api.Models
{
    public class JobExecutedTrackingViewModel
    {
        public ExecutedJob executedJob { get; set; }
        public Job job { get; set; }
        public Tender tender { get; set; }
        public List<JobQuotationApproval> jobQuotationApproval { get; set; }
    }
}