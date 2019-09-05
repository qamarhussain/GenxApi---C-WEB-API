using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GENXAPI.Api.Models
{
    public class JobDataViewModel
    {
        public Tender tender { get; set; }
        public Job job { get; set; }
        public List<JobQuotationApproval> jobQuotations { get; set; }
    }
}