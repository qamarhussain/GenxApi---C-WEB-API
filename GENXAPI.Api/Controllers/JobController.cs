using GENXAPI.Api.Attributes;
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
    [Authorize]
    [CustomExceptionFilter]
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
            //var data = _unitOfWork.Job.AllIncluding(a => a.JobChilds, b => b.Tender.Customer, c => c.Tender.TenderChilds).Where(x => x.CompanyId == model.CompanyId && x.BusinessUnitId == model.BusinessUnitId).ToList();
            var data = _unitOfWork.Job.AllIncluding(b => b.Tender.Customer).Where(x => x.CompanyId == model.CompanyId && x.BusinessUnitId == model.BusinessUnitId).ToList();
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                //var data = _unitOfWork.Job.AllIncluding(a => a.JobChilds, b => b.Tender.Customer, c => c.Tender.TenderChilds, d => d.JobChilds.Select(e=>e.RegionalOffice), f => f.Tender.TenderChilds.Select(g=>g.FleetService), h => h.Tender.TenderDetails, i => i.Tender.TenderDetails.Select(j=>j.City), 
                //    l => l.Tender.TenderDetails.Select(m => m.City1), n => n.Tender.TenderChilds.Select(o => o.Vehicle)).Where(x => x.JobId == id).FirstOrDefault();
                var data = _unitOfWork.Job.AllIncluding(a => a.JobChilds, b => b.JobChilds.Select(c => c.RegionalOffice)).Where(x => x.JobId == id).FirstOrDefault();
                var tender = _unitOfWork.Tenders.AllIncluding(x => x.Customer).Where(m => m.Id == data.TenderId).FirstOrDefault();
                if (tender == null)
                {
                    return NotFound();
                }
                var tenderDetails = _unitOfWork.TenderDetails.AllIncluding(x => x.City, y => y.City1).Where(a => a.TenderId == tender.Id).ToList();
                var tenderChilds = _unitOfWork.TenderChilds.AllIncluding(x => x.FleetService, v => v.Vehicle, z => z.TenderDetail.City, a => a.TenderDetail.City1).Where(a => a.TenderId == tender.Id).ToList();
                tender.TenderDetails = tenderDetails;
                tender.TenderChilds = tenderChilds;
                data.Tender = tender;
                return Ok(data);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
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
                var JobOrder = _unitOfWork.Job.AllIncluding(a => a.JobChilds).Where(x => x.JobId == model.JobId).FirstOrDefault();
                if (JobOrder == null)
                {
                    return NotFound();
                }
                //_unitOfWork.JobChild.RemoveRange(JobOrder.JobChilds.ToArray());
                foreach (var child in JobOrder.JobChilds.ToList())
                    _unitOfWork.JobChild.Remove(child);

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

        [HttpGet]
        public IHttpActionResult GetJobIdsByContractWithoutStatus(int id)
        {
            try
            {
                return Ok(_unitOfWork.Job.GetJobsKeyPairByContractIdWithoutStatus(id));
            }
            catch (Exception ex)
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
                var result = _unitOfWork.Tenders.AllIncluding(x => x.Customer).Where(m => m.Id == model.TenderId).FirstOrDefault();

                if (result == null)
                {
                    return NotFound();
                }
                var tenderDetails = _unitOfWork.TenderDetails.AllIncluding(x => x.City, y => y.City1).Where(a => a.TenderId == result.Id).ToList();
                var tenderChilds = _unitOfWork.TenderChilds.AllIncluding(x => x.FleetService, v => v.Vehicle, z => z.TenderDetail.City, a => a.TenderDetail.City1).Where(a => a.TenderId == result.Id).ToList();
                result.TenderDetails = tenderDetails;
                result.TenderChilds = tenderChilds;
                var jobDetails = _unitOfWork.JobChild.Find(x => x.JobId == model.JobId).ToList();
                if (jobDetails == null)
                {
                    return NotFound();
                }
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

        [HttpGet]
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

        [HttpGet]
        public IHttpActionResult GetJobQuotationByJobId(int id)
        {
            //var data = _unitOfWork.VendorQuotation.AllIncluding(a => a.Vendor, b => b.Tender.Customer, y => y.Tender.TenderDetails, a => a.Tender.TenderDetails.Select(b => b.City), c => c.Tender.TenderDetails.Select(d => d.City1), z => z.Tender.TenderChilds.Select(q => q.FleetService), z => z.Tender.TenderChilds.Select(s => s.Vehicle), p => p.VendorQuotationChilds).Where(e => e.VendorQuotationId == id).FirstOrDefault();
            var data = _unitOfWork.VendorQuotation.AllIncluding(a=>a.Vendor, b=>b.VendorQuotationChilds).Where(e => e.VendorQuotationId == id).FirstOrDefault();
            if(data == null)
            {
                return NotFound();
            }
            var tender = _unitOfWork.Tenders.AllIncluding(x => x.Customer).Where(m => m.Id == data.TenderId).FirstOrDefault();
            if (tender == null)
            {
                return NotFound();
            }
            var tenderDetails = _unitOfWork.TenderDetails.AllIncluding(x => x.City, y => y.City1).Where(a => a.TenderId == tender.Id).ToList();
            var tenderChilds = _unitOfWork.TenderChilds.AllIncluding(x => x.FleetService, v => v.Vehicle, z => z.TenderDetail.City, a => a.TenderDetail.City1).Where(a => a.TenderId == tender.Id).ToList();
            tender.TenderDetails = tenderDetails;
            tender.TenderChilds = tenderChilds;
            data.Tender = tender;

            var jomDetails = data.VendorQuotationChilds.ToList();
            foreach (var item in data.Tender.TenderChilds.ToList())
            {
                var itemCodeInJob = jomDetails.Where(x => x.ItemCode == item.ItemCode).FirstOrDefault();
                if (itemCodeInJob == null)
                {
                    data.Tender.TenderChilds.Remove(item);
                }
            }
            return Ok(data);
        }

        [HttpGet]
        public IHttpActionResult GetJobForApproval(int id)
        {
            try
            {
                var data = _unitOfWork.VendorQuotationChild.AllIncluding(x => x.VendorQuotation, y => y.VendorQuotation.Vendor).Where(e => e.VendorQuotation.JobId == id).ToList();
                var results = (from ssi in data
                                   // here I choose each field I want to group by
                               group ssi by new { ssi.ItemCode } into g
                               select new { ItemCode = g.Key.ItemCode, vendorInfo = g.ToList() }).ToList();
                var viewModelList = new List<JobQuotationApprovalViewModel>();
                foreach (var item in results)
                {
                    var obj = new JobQuotationApprovalViewModel();
                    var itemCodeDetail = _unitOfWork.TenderChilds.AllIncluding(x => x.FleetService, v => v.Vehicle, z => z.TenderDetail.City, a => a.TenderDetail.City1).Where(a => a.ItemCode == item.ItemCode).FirstOrDefault();
                    if (itemCodeDetail != null)
                    {
                        obj.JobId = item.vendorInfo.First().VendorQuotation.JobId;
                        obj.JobNo = item.vendorInfo.First().VendorQuotation.JobNo;
                        obj.VendorQuotationId = item.vendorInfo.First().VendorQuotationId;
                        obj.VendorQUotationChildId = item.vendorInfo.First().VendorQuotationChildId;
                        obj.ItemCode = item.ItemCode;
                        if (itemCodeDetail.FleetServiceId != null)
                            obj.Particulars = itemCodeDetail.FleetService.ServiceName;
                        else
                            obj.Particulars = itemCodeDetail.TenderDetail.City.Name + " To " + itemCodeDetail.TenderDetail.City1.Name;

                        foreach (var p in item.vendorInfo)
                        {
                            obj.vendorInfo.Add(new JobQuotationApprovalViewModelVendors()
                            {
                                VendorId = p.VendorQuotation.VendorId,
                                VendorName = p.VendorQuotation.Vendor.VendorName,
                                Amount = p.Amount
                            });
                        }

                    }
                    viewModelList.Add(obj);
                }

                //var result = GetGroupedJobQuotations(viewModelList);



                return Ok(viewModelList);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AddJobQuotationApproval(JobQuotationApprovalCreateViewModel model)
        {
            try
            {
                foreach(var item in model.listItemCodes)
                {
                    item.CustomerId = model.CustomerId;
                    item.JobId = model.JobId;
                    item.JobNo = model.JobNo;
                    item.ContractId = model.ContractId;
                }
                _unitOfWork.JobQuotationApproval.AddRange(model.listItemCodes);

                var jobOrderToUpdateStatus = _unitOfWork.Job.Get(model.JobId);
                jobOrderToUpdateStatus.JobStatus = (byte)TenderUtility.JobApprovalState;
                _unitOfWork.Job.Update(jobOrderToUpdateStatus);
                _unitOfWork.SaveChanges();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetJobsByContractForExecution(int id)
        {
            try
            {
                var data = _unitOfWork.JobQuotationApproval.GetJobsKeyPairByContract(id);
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult GetExecutedJobs(CompanyBusinessUntiInfoViewModel model)
        {
            try
            {
                var data = _unitOfWork.Job.AllIncluding(e=>e.Customer).Where(x => x.ExecutionStatus == (byte)JobExecutionStatus.Executed).ToList();
                return Ok(data);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetJobDataToExecute(int id)
        {
            try
            {
                var data = new JobDataViewModel();
                data.jobQuotations = _unitOfWork.JobQuotationApproval.AllIncluding(e=>e.Vendor).Where(x => x.JobId == id).ToList();
                var job = _unitOfWork.Job.AllIncluding(x=>x.JobChilds).Where(e=>e.JobId == id).FirstOrDefault();
                if(job == null)
                {
                    return NotFound();
                }
                data.job = job;
                var tender = _unitOfWork.Tenders.AllIncluding(x => x.Customer).Where(m => m.Id == job.TenderId).FirstOrDefault();
                if (tender == null)
                {
                    return NotFound();
                }
                var tenderDetails = _unitOfWork.TenderDetails.AllIncluding(x => x.City, y => y.City1).Where(a => a.TenderId == tender.Id).ToList();
                var tenderChilds = _unitOfWork.TenderChilds.AllIncluding(x => x.FleetService, v => v.Vehicle, z => z.TenderDetail.City, a => a.TenderDetail.City1).Where(a => a.TenderId == tender.Id).ToList();
                tender.TenderDetails = tenderDetails;
                tender.TenderChilds = tenderChilds;
                data.tender = tender;
                return Ok(data);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
