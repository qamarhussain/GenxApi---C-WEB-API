using GENXAPI.Api.Attributes;
using GENXAPI.Api.Models;
using GENXAPI.Api.Utilities;
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
    public class VendorQuotationController : ApiController
    {
        IUnitOfWork _unitOfWork;
        public VendorQuotationController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IHttpActionResult GetAllVendorQuotation()
        {
            try
            {
                //return Ok(_unitOfWork.VendorQuotation.AllIncluding(a=>a.Tender, b=>b.Tender.TenderChilds, c => c.Tender.TenderChilds.Select(d=>d.FleetService),
                //e => e.Tender.TenderChilds.Select(f => f.Vehicle), i => i.Tender.TenderDetails.Select(j => j.City), l => l.Tender.TenderDetails.Select(m => m.City1),
                //x => x.Tender.Customer, y => y.Vendor, z => z.VendorQuotationChilds).ToList());
                var data = _unitOfWork.VendorQuotation.AllIncluding(x => x.Tender.Customer, y => y.Vendor).ToList();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            //var data = _unitOfWork.VendorQuotation.AllIncluding(a => a.Vendor, b => b.Tender.Customer, y => y.Tender.TenderDetails, a => a.Tender.TenderDetails.Select(b => b.City), c =>c.Tender.TenderDetails.Select(d => d.City1), z => z.Tender.TenderChilds.Select(q => q.FleetService), z => z.Tender.TenderChilds.Select(s => s.Vehicle), p => p.VendorQuotationChilds).Where(e => e.VendorQuotationId == id).FirstOrDefault();
            var data = _unitOfWork.VendorQuotation.AllIncluding(x => x.Vendor, y => y.VendorQuotationChilds).Where(z => z.VendorQuotationId == id).FirstOrDefault();
            if (data == null)
            {
                return NotFound();
            }
            var tender = _unitOfWork.Tenders.AllIncluding(x => x.Customer).Where(m => m.Id == data.TenderId).FirstOrDefault();
            if (tender == null)
            {
                return NotFound();
            }
            var tenderDetails = _unitOfWork.TenderDetails.AllIncluding(x => x.City, y => y.City1).Where(a => a.TenderId == tender.Id).ToList();
            var tenderChilds = _unitOfWork.TenderChilds.AllIncluding(x => x.FleetService, a =>a.FleetService.Unit, v => v.Vehicle, z => z.TenderDetail.City, a => a.TenderDetail.City1).Where(a => a.TenderId == tender.Id).ToList();
            tender.TenderDetails = tenderDetails;
            tender.TenderChilds = tenderChilds;
            data.Tender = tender;
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult CreateVendorQuotation(VendorQuotationCreateViewModel model)
        {
            var vendorQuotation = new VendorQuotation();
            vendorQuotation.CompanyId = model.CompanyId;
            vendorQuotation.BusinessUnitId = model.BusinessUnitId;
            vendorQuotation.CreatedBy = model.CreatedBy;
            vendorQuotation.StatusId = (byte)Status.Active;
            vendorQuotation.JobId = (model.JobId == null || model.JobId == 0) ? null : model.JobId;
            vendorQuotation.JobNo = (model.JobId == null || model.JobId == 0) ? null : model.JobNo;
            vendorQuotation.TenderId = model.TenderId;
            vendorQuotation.VendorId = model.VendorId;
            vendorQuotation.VendorQuotationChilds = model.vendorQuotationChild;
            vendorQuotation.CreatedOn = DateTime.Now;
            vendorQuotation.LastModifiedBy = model.LastModifiedBy;
            vendorQuotation.LastModifiedDate = DateTime.Now;
            _unitOfWork.VendorQuotation.Add(vendorQuotation);
            _unitOfWork.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult UpdateVendorQuotation(VendorQuotationCreateViewModel model)
        {
            try
            {
                var quotationModal = _unitOfWork.VendorQuotation.AllIncluding(x => x.VendorQuotationChilds).Where(e => e.VendorQuotationId == model.VendorQuotationId).FirstOrDefault();
                if (quotationModal == null)
                {
                    return NotFound();
                }
                //_unitOfWork.VendorQuotationChild.RemoveRange(quotationModal.VendorQuotationChilds.ToArray());
                foreach (var child in quotationModal.VendorQuotationChilds.ToList())
                    _unitOfWork.VendorQuotationChild.Remove(child);
                quotationModal.LastModifiedBy = model.LastModifiedBy;
                quotationModal.LastModifiedDate = DateTime.Now;
                quotationModal.VendorQuotationChilds = model.vendorQuotationChild;
                _unitOfWork.VendorQuotation.Update(quotationModal);
                _unitOfWork.SaveChanges();
                return Ok(quotationModal);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        public IHttpActionResult GetQoutationByContractId(int Id)
        {
            var data = _unitOfWork.VendorQuotation.AllIncluding(a => a.Vendor, b => b.Tender.Customer, y => y.Tender.TenderDetails, z => z.Tender.TenderChilds.Select(q => q.FleetService), z => z.Tender.TenderChilds.Select(s => s.Vehicle), p => p.VendorQuotationChilds).Where(e => e.TenderId == Id).FirstOrDefault();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

       
        [HttpPost]
        public IHttpActionResult CheckVendorExistOnJobId(CompanyBusinessUntiInfoViewModel model)
        {
            var isExist = _unitOfWork.VendorQuotation.Find(a => a.JobId == model.JobId && a.VendorId == model.VendorId).FirstOrDefault();
           
            if (isExist == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(isExist);
            }
           
        }
    

    }
}
