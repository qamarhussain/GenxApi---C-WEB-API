﻿using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GENXAPI.Api.Models
{
    public class TenderCreateViewModel
    {
        public TenderCreateViewModel()
        {
            TenderDetails = new List<AML_TenderDetail>();
            TenderChilds = new List<AML_TenderChild>();
        }
        public List<AML_TenderDetail> TenderDetails { get; set; }
        public List<AML_TenderChild> TenderChilds { get; set; }

        public int Id { get; set; }
        public string TenderReference { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime IssuanceDate { get; set; }
        public string TenderSource { get; set; }
        public string TenderTerm { get; set; }
        public int StatusId { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public string TenderNo { get; set; }
        public int ProvinceId { get; set; }


    }
}