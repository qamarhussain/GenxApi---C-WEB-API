using GENXAPI.Repisitory;
using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using GENXAPI.Repisitory.Repositories;
using GENXAPI.Utilities;
using GENXAPI.Api.Models;

namespace GENXAPI.Api.Controllers
{
    public class VendorController : ApiController
    {
        protected readonly VendorRepo _vendorRepo = new VendorRepo();
        protected readonly CurrencyRepo _currencyRepo = new CurrencyRepo();
        protected readonly VendorOrgTypeRepo _vendorOrgTypeRepo = new VendorOrgTypeRepo();
        protected readonly VendorBusinessNatureRepo _vendorBusinessNatureRepo = new VendorBusinessNatureRepo();

        [HttpGet]
        public IHttpActionResult GetAllVendors()
        {
            try
            {
                var result = _vendorRepo.GetAll().ToList();
                return Ok(result);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var vendor = _vendorRepo.Get(id);
                if(vendor == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(vendor);
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        public IHttpActionResult CreateVendor([FromBody]Vendor vendor)
        {
            try
            {
                vendor.StatusId = (byte)Status.Active;
                vendor.CreatedOn = DateTime.Now;
                vendor.LastModifiedDate = DateTime.Now;
                _vendorRepo.Create(vendor);
                return Ok(vendor);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        public IHttpActionResult UpdateVendor(int id, [FromBody]Vendor vendor)
        {
            try
            {
                var vendorModel = _vendorRepo.Get(id);
                if (vendorModel == null)
                {
                    return NotFound();
                }
                vendorModel.Phone = vendor.Phone;
                vendorModel.AccountNo = vendor.AccountNo;
                vendorModel.Address = vendor.Address;
                vendorModel.City = vendor.City;
                vendorModel.CNIC = vendor.CNIC;
                vendorModel.CompanyId = vendor.CompanyId;
                vendorModel.ContactPerson = vendor.ContactPerson;
                vendorModel.CopyStatus = vendor.CopyStatus;
                vendorModel.Country = vendor.Country;
                vendorModel.CurrencyId = vendor.CurrencyId;
                vendorModel.Email = vendor.Email;
                vendorModel.FaxNo = vendor.FaxNo;
                vendorModel.LastModifiedBy = vendor.LastModifiedBy;
                vendorModel.MobileNumber = vendor.MobileNumber;
                vendorModel.NatureOfBusinessId = vendor.NatureOfBusinessId;
                vendorModel.NTN = vendor.NTN;
                vendorModel.Remarks = vendor.Remarks;
                vendorModel.State = vendor.State;
                vendorModel.StatusId = vendor.StatusId;
                vendorModel.STRN = vendor.STRN;
                vendorModel.TypeOfBusinessId = vendor.TypeOfBusinessId;
                vendorModel.VendorName = vendor.VendorName;
                vendorModel.VendorType = vendor.VendorType;
                vendorModel.YearEstablished = vendor.YearEstablished;
                vendorModel.LastModifiedDate = DateTime.Now;
                _vendorRepo.Update(vendorModel);
                return Ok(vendorModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpDelete]
        public IHttpActionResult DeleteVendor(int id)
        {
            try
            {
                var vendorModel = _vendorRepo.Get(id);
                if (vendorModel == null)
                {
                    return NotFound();
                }

                _vendorRepo.Delete(id);
                return Ok(vendorModel);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        public IHttpActionResult GetKeyPair()
        {
            try
            {
                var keyPairValues = _vendorRepo.GetKeyPairValue();
                return Ok(keyPairValues);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetKeyPairCurrencyBusinessTypeBusinessNature()
        {
            VendorViewModel Obj = new VendorViewModel();
            var CurrencyKeyPairValue = _currencyRepo.GetKeyPairValue().ToList();
            var VendorOrgTypeKeyPairValue = _vendorOrgTypeRepo.GetKeyPairValue().ToList();
            var VendorBusinessNatureKeyPairValue = _vendorBusinessNatureRepo.GetKeyPairValue().ToList();

            Obj.CurrencyKeyPairValue = CurrencyKeyPairValue;
            Obj.VendorBusinessNatureKeyPairValue = VendorBusinessNatureKeyPairValue;
            Obj.VendorOrgTypeKeyPairValue = VendorOrgTypeKeyPairValue;

            return Ok(Obj);
        }
    }
}