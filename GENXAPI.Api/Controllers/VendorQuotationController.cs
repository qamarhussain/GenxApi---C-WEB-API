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
    public class VendorQuotationController : ApiController
    {
        IUnitOfWork _unitOfWork;
        public VendorQuotationController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IHttpActionResult GetAllVendorQuotation()
        {
            return Ok(_unitOfWork.VendorQuotation.AllIncluding(x => x.Tender.Customer, y => y.Vendor, z => z.VendorQuotationChilds).ToList());
        }

        [HttpPost]
        public IHttpActionResult CreateVendorQuotation(VendorQuotationCreateViewModel model)
        {
            var vendorQuotation = new VendorQuotation();
            vendorQuotation.CompanyId = model.CompanyId;
            vendorQuotation.BusinessUnitId = model.BusinessUnitId;
            vendorQuotation.CreatedBy = model.CreatedBy;
            vendorQuotation.StatusId = (byte)Status.Active;
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

        [HttpGet]
        public IHttpActionResult GetQoutationByContractId(int Id)
        {
            var data = _unitOfWork.VendorQuotation.AllIncluding(a=>a.Vendor, b=>b.Tender.Customer, y => y.Tender.TenderDetails, z => z.Tender.TenderChilds.Select(q => q.FleetService), z => z.Tender.TenderChilds.Select(s => s.Vehicle), p => p.VendorQuotationChilds).Where(e => e.TenderId == Id).FirstOrDefault();
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
