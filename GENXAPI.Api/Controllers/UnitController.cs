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

    public class UnitController : ApiController
    {
        protected readonly UnitRepo _unitRepo = new UnitRepo();
        
        [HttpGet]
        public IHttpActionResult GetAllUnits()
        {
            try
            {
                var result = _unitRepo.GetAll().ToList();
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
                var unit = _unitRepo.Get(id);
                if (unit == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(unit);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        
        [HttpPost]
        public IHttpActionResult CreateUnit([FromBody]Unit unit)
        {
            try
            {
                unit.StatusId = (byte)Status.Active;
                unit.CreatedOn = DateTime.Now;
                unit.LastModifiedDate = DateTime.Now;
                _unitRepo.Create(unit);
                return Ok(unit);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Customer/5
        [HttpPut]
        public IHttpActionResult UpdateUnit(int id, [FromBody]Unit unit)
        {
            try
            {
                var unitModel = _unitRepo.Get(id);
                if (unitModel == null)
                {
                    return NotFound();
                }
                unitModel.Title = unit.Title;
                unitModel.Abbreviation = unit.Abbreviation;
                unitModel.LastModifiedBy = unit.LastModifiedBy;
                unitModel.StatusId = unit.StatusId;
                unitModel.LastModifiedDate = DateTime.Now;
                _unitRepo.Update(unitModel);
                return Ok(unitModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
        
        [HttpDelete]
        public IHttpActionResult DeleteUnit(int id)
        {

            try
            {
                var unitModel = _unitRepo.Get(id);
                if (unitModel == null)
                {
                    return NotFound();
                }

                _unitRepo.Delete(id);
                return Ok(unitModel);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        public IHttpActionResult GetKeyPair()
        {
            try
            {
                var keyPairValues = _unitRepo.GetKeyPairValue();
                return Ok(keyPairValues);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

    }
}
