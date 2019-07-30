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
    public class VehicleController : ApiController
    {
        protected readonly VehicleRepo _vehicleRepo = new VehicleRepo();
        // GET: api/Customer
        [HttpGet]
        public IHttpActionResult GetAllVehicles()
        {
            try
            {
                var result = _vehicleRepo.GetAll().ToList();
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
                var vehicle = _vehicleRepo.Get(id);
                if (vehicle == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(vehicle);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Customer
        [HttpPost]
        public IHttpActionResult CreateVehicle([FromBody]Vehicle vehicle)
        {
            try
            {
                vehicle.StatusId = (byte)Status.Active;
                vehicle.CreatedOn = DateTime.Now;
                vehicle.LastModifiedDate = DateTime.Now;
                _vehicleRepo.Create(vehicle);
                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Customer/5
        [HttpPut]
        public IHttpActionResult UpdateVehicle(int id, [FromBody]Vehicle vehicle)
        {
            try
            {
                var vehicleModel = _vehicleRepo.Get(id);
                if (vehicleModel == null)
                {
                    return NotFound();
                }
                vehicleModel.Type = vehicle.Type;
                vehicleModel.Weight = vehicle.Weight;
                vehicleModel.Title = vehicle.Title;
                vehicleModel.BusinessUnitId = vehicle.BusinessUnitId;
                vehicleModel.CompanyId = vehicle.CompanyId;
                vehicleModel.LastModifiedBy = vehicle.LastModifiedBy;
                vehicleModel.LastModifiedDate = vehicle.LastModifiedDate;
                vehicleModel.StatusId = vehicle.StatusId;
                _vehicleRepo.Update(vehicleModel);
                return Ok(vehicleModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // DELETE: api/Customer/5
        [HttpDelete]
        public IHttpActionResult DeleteVehicle(int id)
        {

            try
            {
                var vehicleModel = _vehicleRepo.Get(id);
                if (vehicleModel == null)
                {
                    return NotFound();
                }

                _vehicleRepo.Delete(id);
                return Ok(vehicleModel);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPost]
        public IHttpActionResult GetKeyPair(CompanyBusinessUntiInfoViewModel model)
        {
            try
            {
                var keyPairValues = _vehicleRepo.GetKeyPairValue(Convert.ToInt32(model.CompanyId), Convert.ToInt32(model.BusinessUnitId));
                return Ok(keyPairValues);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

    }
}
