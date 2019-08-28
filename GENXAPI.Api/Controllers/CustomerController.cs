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
    public class CustomerController : ApiController
    {
        //protected readonly CustomerRepo _customerRepo = new CustomerRepo();
        //protected readonly TenderRepo _tenderRepo = new TenderRepo();
        IUnitOfWork _unitOfWork;
        public CustomerController()
        {
            _unitOfWork = new UnitOfWork();
        }
        // GET: api/Customer
        [HttpGet]
        public IHttpActionResult GetAllCustomers()
        {
            try
            {
                //var result = _customerRepo.AllIncluding(x => x.Tenders).ToList();
                var result = _unitOfWork.Customers.GetAll().ToList();
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
           
        }

        // GET: api/Customer/5
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                //var customer = _customerRepo.Get(id);
                var customer = _unitOfWork.Customers.Get(id);

                if (customer == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(customer);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Customer
        [HttpPost]
        public IHttpActionResult CreateCustomer([FromBody]Customer customer)
        {
            try
            {
                customer.StatusId = (byte)Status.Active;
                customer.CreatedOn = DateTime.Now;
                customer.LastModifiedDate = DateTime.Now;
                //_customerRepo.Create(customer);
                _unitOfWork.Customers.Add(customer);
                _unitOfWork.SaveChanges();
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Customer/5
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, [FromBody]Customer customer)
        {
            try
            {
                //var customerModel = _customerRepo.Get(id);
                var customerModel = _unitOfWork.Customers.Get(id);
                if (customerModel == null)
                {
                    return NotFound();
                }
                customerModel.LastModifiedDate = DateTime.Now;
                customerModel.LastModifiedBy = customerModel.LastModifiedBy;
                customerModel.Phone = customer.Phone;
                customerModel.AccountCode = customer.AccountCode;
                customerModel.AccountNo = customer.AccountNo;
                customerModel.Address = customer.Address;
                customerModel.CustomerBusinessLineId = customer.CustomerBusinessLineId;
                customerModel.BusinessUnitId = customer.BusinessUnitId;
                customerModel.City = customer.City;
                customerModel.CityId = customer.CityId;
                customerModel.CNIC = customer.CNIC;
                customerModel.CompanyId = customer.CompanyId;
                customerModel.ContactPerson = customer.ContactPerson;
                customerModel.Country = customer.Country;
                customerModel.CreditLimit = customer.CreditLimit;
                customerModel.Discount = customer.Discount;
                customerModel.Email = customer.Email;
                customerModel.FaxNo = customer.FaxNo;
                customerModel.Mobile = customer.Mobile;
                customerModel.Name = customer.Name;
                customerModel.NTN = customer.NTN;
                customerModel.RegDate = customer.RegDate;
                customerModel.Region = customer.Region;
                customerModel.RegionId = customer.RegionId;
                customerModel.Remarks = customer.Remarks;
                customerModel.State = customer.State;
                customerModel.StatusId = customer.StatusId;
                customerModel.STRN = customer.STRN;
                customerModel.Type = customer.Type;
                customerModel.ZoneId = customer.ZoneId;
                customerModel.Abbreviation = customer.Abbreviation;
                //_customerRepo.Update(customerModel);
                _unitOfWork.Customers.Update(customerModel);
                _unitOfWork.SaveChanges();
                return Ok(customerModel);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
           
        }

        // DELETE: api/Customer/5
        //[HttpDelete]
        //public IHttpActionResult DeleteCustomer(int id)
        //{

        //    try
        //    {
        //        var customerModel = _customerRepo.Get(id);
        //        if (customerModel == null)
        //        {
        //            return NotFound();
        //        }

        //        _customerRepo.Delete(id);
        //        return Ok(customerModel);
        //    }

        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }

        //}

        
        [HttpPost]
        public IHttpActionResult GetKeyPair(CompanyBusinessUntiInfoViewModel model)
        {
            try
            {
                var keyPairValues = _unitOfWork.Customers.GetKeyPairValue(Convert.ToInt32(model.CompanyId), Convert.ToInt32(model.BusinessUnitId));
                return Ok(keyPairValues);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
           
        }

        [HttpGet]
        public IHttpActionResult GetCustomerTenderItemCode(int id)
        {
            try
            {
                //var customer = _customerRepo.Get(id);
                var customer = _unitOfWork.Customers.Get(id);
                if (customer == null)
                {
                    return NotFound();
                }
                //int customerTenderCount = _tenderRepo.Find(x => x.CustomerId == id).Count();
                int customerTenderCount = _unitOfWork.Tenders.Find(x => x.CustomerId == id).Count();
                var code = customer.Abbreviation + "-" + (customerTenderCount + 1);
                return Ok(code);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult GetCustomerBusinessLine(CompanyBusinessUntiInfoViewModel model)
        {
            try
            {
                return Ok(_unitOfWork.CustomerBusinessLine.GetKeyPairValue(Convert.ToInt32(model.CompanyId), Convert.ToInt32(model.BusinessUnitId)).ToList());
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
