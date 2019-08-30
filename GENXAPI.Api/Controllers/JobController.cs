using GENXAPI.Api.Models;
using GENXAPI.Repisitory;
using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GENXAPI.Api.Controllers
{
    public class JobController : ApiController
    {
        IUnitOfWork _unitOfWork;
        public JobController()
        {
            _unitOfWork = new UnitOfWork();
        }

        [HttpPost]
        public IHttpActionResult GetAllJobOrders(CompanyBusinessUntiInfoViewModel model)
        {
            var data = _unitOfWork.Job.AllIncluding(a => a.JobChilds, b => b.Tender.Customer, c => c.Tender.TenderChilds).Where(x => x.CompanyId == model.CompanyId && x.BusinessUnitId == model.BusinessUnitId).ToList();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var data = _unitOfWork.Job.AllIncluding(a => a.JobChilds, b => b.Tender.Customer, c => c.Tender.TenderChilds, d => d.JobChilds.Select(e=>e.RegionalOffice), f => f.Tender.TenderChilds.Select(g=>g.FleetService), h => h.Tender.TenderDetails, i => i.Tender.TenderDetails.Select(j=>j.City), 
                l => l.Tender.TenderDetails.Select(m => m.City1), n => n.Tender.TenderChilds.Select(o => o.Vehicle)).Where(x => x.JobId == id).FirstOrDefault();
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        // Used to get contract to make a job.
        [HttpPost]
        public IHttpActionResult GetContractForJob(CompanyBusinessUntiInfoViewModel model)
        {
            try
            {
                var keyPairValues = _unitOfWork.Tenders.GetContractKeyPairForJob(model.CustomerId);
                return Ok(keyPairValues);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult CreateJobOrder(JobOrderCreateViewModel model)
        {
            try
            {
               
                var JobOrder = new Job();
                JobOrder.CompanyId = model.CompanyId;
                JobOrder.BusinessUnitId = model.BusinessUnitId;
                JobOrder.CustomerId = model.CustomerId;
                JobOrder.JobNo = model.JobNo;
                JobOrder.PONo = model.PONo;
                JobOrder.DeliveryAddress = model.DeliveryAddress;
                JobOrder.DeliveryDate = model.DeliveryDate;
                JobOrder.InvoiceAddress = model.InvoiceAddress;
                JobOrder.JobStatus = (byte)Status.Active;
                JobOrder.OtherTermsConditions = model.OtherTermsConditions;
                JobOrder.PODate = model.PODate;
                JobOrder.PRNo = model.PRNo;
                JobOrder.ProposalRef = model.ProposalRef;
                JobOrder.Remarks = model.Remarks;
                JobOrder.StatusId = (byte)Status.Active;
                JobOrder.TenderId = model.TenderId;
                JobOrder.TenderNo = model.TenderNo;
                JobOrder.CreatedOn = DateTime.Now;
                JobOrder.LastModifiedDate = DateTime.Now;
                JobOrder.CreatedBy = model.CreatedBy;
                JobOrder.LastModifiedBy = model.LastModifiedBy;
                var listJobDetails = new List<JobChild>();
                foreach (var item in model.JobChilds)
                {
                    listJobDetails.Add(new JobChild
                    {
                        JobId=JobOrder.JobId,
                        ItemCode = item.ItemCode,
                        Amount = item.Amount,
                        DetailedDescription = item.DetailedDescription,
                        OfficeId = item.OfficeId,
                        Quantity = item.Quantity,
                        UnitCost = item.UnitCost,
                        UnitOfMesure = item.UnitOfMesure,
                    });
                }
                JobOrder.JobChilds = listJobDetails;
                var tenderToUpdateStatus = _unitOfWork.Tenders.Get(JobOrder.TenderId);
                tenderToUpdateStatus.ProceedStatus = (byte)TenderUtility.JobOrderState;
                _unitOfWork.Tenders.Update(tenderToUpdateStatus);
                _unitOfWork.Job.Add(JobOrder);
                _unitOfWork.SaveChanges();
                return Ok(JobOrder);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateJobOrder(JobOrderCreateViewModel model)
        {
            try
            {
                var JobOrder = _unitOfWork.Job.AllIncluding(a => a.JobChilds, b => b.Tender.Customer, c => c.Tender.TenderChilds, d => d.JobChilds.Select(e => e.RegionalOffice)).Where(x => x.JobId == model.JobId).FirstOrDefault();
                if (JobOrder == null)
                {
                    return NotFound();
                }
                _unitOfWork.JobChild.RemoveRange(JobOrder.JobChilds.ToArray());

                JobOrder.PONo = model.PONo;
                JobOrder.DeliveryAddress = model.DeliveryAddress;
                JobOrder.DeliveryDate = model.DeliveryDate;
                JobOrder.InvoiceAddress = model.InvoiceAddress;
                JobOrder.JobStatus = (byte)Status.Active;
                JobOrder.OtherTermsConditions = model.OtherTermsConditions;
                JobOrder.PODate = model.PODate;
                JobOrder.PRNo = model.PRNo;
                JobOrder.ProposalRef = model.ProposalRef;
                JobOrder.Remarks = model.Remarks;
                JobOrder.StatusId = (byte)Status.Active;
                JobOrder.LastModifiedDate = DateTime.Now;
                JobOrder.LastModifiedBy = model.LastModifiedBy;
                var listJobDetails = new List<JobChild>();
                foreach (var item in model.JobChilds)
                {
                    listJobDetails.Add(new JobChild
                    {
                        JobId = JobOrder.JobId,
                        ItemCode = item.ItemCode,
                        Amount = item.Amount,
                        DetailedDescription = item.DetailedDescription,
                        OfficeId = item.OfficeId,
                        Quantity = item.Quantity,
                        UnitCost = item.UnitCost,
                        UnitOfMesure = item.UnitOfMesure,
                    });
                }
                JobOrder.JobChilds = listJobDetails;
                _unitOfWork.Job.Update(JobOrder);
                _unitOfWork.SaveChanges();
                return Ok(JobOrder);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult GetJobsCountByCustomerContract(JobOrderCreateViewModel model)
        {
            try
            {
                return Ok(_unitOfWork.Job.Find(x => x.CustomerId == model.CustomerId && x.TenderId == model.TenderId).Count());
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetJobIdsByContract(int id)
        {
            try
            {
                return Ok(_unitOfWork.Job.GetJobsKeyPairByContract(id));
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult GetContractsByCustomerForJobQuotation(CompanyBusinessUntiInfoViewModel model)
        {
            try
            {
                var keyPairValues = _unitOfWork.Tenders.GetContractKeyPairForJob(model.CustomerId);
                return Ok(keyPairValues);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult GetJobForQuotation(JobOrderCreateViewModel model)
        {
            try
            {
                var result = _unitOfWork.Tenders.AllIncluding(x => x.Customer, y => y.TenderDetails, a => a.TenderDetails.Select(b => b.City), c => c.TenderDetails.Select(d => d.City1), z => z.TenderChilds.Select(q => q.FleetService), z => z.TenderChilds.Select(s => s.Vehicle)).Where(o => o.Id == model.TenderId).FirstOrDefault();
                if (result == null)
                {
                    return NotFound();
                }
                var jobDetails = _unitOfWork.JobChild.Find(x => x.JobId == model.JobId).ToList();
                if (jobDetails == null)
                {
                    return NotFound();
                }
                var childTemList = result.TenderChilds;
                foreach (var item in result.TenderChilds.ToList())
                {
                    var itemCodeInJob = jobDetails.Where(x => x.ItemCode == item.ItemCode).FirstOrDefault();
                    if (itemCodeInJob == null)
                    {
                        result.TenderChilds.Remove(item);
                    }
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
       
        }

        public IHttpActionResult GetAllJobQuotation()
        {
            try
            {
                var data = _unitOfWork.VendorQuotation.AllIncluding(x => x.Tender.Customer, y => y.Vendor).Where(d=>d.JobId != null).ToList();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }


    }
}
