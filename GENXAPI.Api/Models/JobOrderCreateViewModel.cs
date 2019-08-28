using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GENXAPI.Api.Models
{
    public class JobOrderCreateViewModel
    {
        public int JobId { get; set; }
        public int TenderId { get; set; }
        public string TenderNo { get; set; }
        public byte JobStatus { get; set; }
        public string PONo { get; set; }
        public Nullable<System.DateTime> PODate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string PRNo { get; set; }
        public string ProposalRef { get; set; }
        public string Remarks { get; set; }
        public string OtherTermsConditions { get; set; }
        public string InvoiceAddress { get; set; }
        public string DeliveryAddress { get; set; }
        public byte StatusId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> BusinessUnitId { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<int> LastModifiedBy { get; set; }


        public virtual List<JobChildViewModel> JobChilds { get; set; }
    }

    public class JobChildViewModel
    {
        public int Id { get; set; }
        public Nullable<int> JobId { get; set; }
        public string ItemCode { get; set; }
        public string DetailedDescription { get; set; }
        public string UnitOfMesure { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> UnitCost { get; set; }
        public Nullable<int> OfficeId { get; set; }
    }
}