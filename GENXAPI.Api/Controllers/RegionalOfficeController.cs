using GENXAPI.Repisitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GENXAPI.Api.Models;
using GENXAPI.Api.Attributes;
using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;

namespace GENXAPI.Api.Controllers
{
    [Authorize]
    [CustomExceptionFilter]

    public class RegionalOfficeController : ApiController
    {
        IUnitOfWork _unitOfWork;
        public RegionalOfficeController()
        {
            _unitOfWork = new UnitOfWork();
        }
        [HttpGet]
        public IHttpActionResult GetAllRegionlOffice()
        {
            try
            {
                var result = _unitOfWork.RegionalOffice.AllIncluding(a =>a.City).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var result = _unitOfWork.RegionalOffice.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult CreaterRegionalOffice([FromBody]RegionalOffice regionalOffice)
        {
            try
            {
                regionalOffice.StatusId = (byte)Status.Active;
                regionalOffice.CreatedOn = DateTime.Now;
                regionalOffice.LastModifiedDate = DateTime.Now;
                _unitOfWork.RegionalOffice.Add(regionalOffice);
                _unitOfWork.SaveChanges();
                return Ok(regionalOffice);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateRegionalOffice(int id, [FromBody]RegionalOffice regionalOffice)
        {
            try
            {
                var regionalModel = _unitOfWork.RegionalOffice.Get(id);
                if (regionalModel == null)
                {
                    return NotFound();
                }
                regionalModel.LastModifiedDate = DateTime.Now;
                regionalModel.LastModifiedBy = regionalModel.LastModifiedBy;
                regionalModel.CityId = regionalOffice.CityId;
                regionalModel.OfficeName = regionalOffice.OfficeName;
                regionalModel.Abbreviation = regionalOffice.Abbreviation;
                regionalModel.StatusId = regionalOffice.StatusId;

                _unitOfWork.RegionalOffice.Update(regionalModel);
                _unitOfWork.SaveChanges();
                return Ok(regionalModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
        public IHttpActionResult GetAllRegionalOffices(CompanyBusinessUntiInfoViewModel model)
        {
            try
            {
                var data = _unitOfWork.RegionalOffice.AllIncluding(d=>d.City).Where(x => x.CompanyId == model.CompanyId && x.BusinessUnitId == model.BusinessUnitId).ToList();
                return Ok(data);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult GetKeyPair(CompanyBusinessUntiInfoViewModel model)
        {
            return Ok(_unitOfWork.RegionalOffice.GetKeyPair(model.CompanyId, model.BusinessUnitId));
        }

    }
}
