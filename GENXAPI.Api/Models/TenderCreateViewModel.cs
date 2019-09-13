using GENXAPI.Repisitory.Model;
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
            TenderDetails = new List<TenderDetail>();
            TenderChilds = new List<TenderChild>();
        }
        public List<TenderDetail> TenderDetails { get; set; }
        public List<TenderChild> TenderChilds { get; set; }

        public int Id { get; set; }
        public string TenderReference { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime IssuanceDate { get; set; }
        public string TenderSource { get; set; }
        public string TenderTerm { get; set; }
        public DateTime TenderExpiryDate { get; set; }
        public string Gst { get; set; }
        public string FurthurTax { get; set; }
        public string AdditionalTax { get; set; }
        public string WithHoldingTax { get; set; }
        public int StatusId { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public string TenderNo { get; set; }
        public int ProvinceId { get; set; }
        public Nullable<int> RegionId { get; set; }


    }
}