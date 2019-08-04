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
    public class FleetServiceController : ApiController
    {
        protected readonly FleetServiceRepo _fleetServiceRepo = new FleetServiceRepo();
        // GET: api/Customer
        //[HttpGet]
        //public IHttpActionResult GetAllFleetServices()
        //{
        //    try
        //    {
        //        var result = _fleetServiceRepo.AllIncluding(x => x.TenderChilds).ToList();
        //        return Ok(result);
        //    }
        //    catch (Exception)
        //    {
        //        return InternalServerError();
        //    }

        //}

        // GET: api/Customer/5
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var fleetService = _fleetServiceRepo.Get(id);
                if (fleetService == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(fleetService);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Customer
        [HttpPost]
        public IHttpActionResult CreateFleetService([FromBody]FleetService fleetService)
        {
            try
            {
                fleetService.StatusId = (byte)Status.Active;
                fleetService.CreatedOn = DateTime.Now;
                fleetService.LastModifiedDate = DateTime.Now;

                _fleetServiceRepo.Create(fleetService);
                return Ok(fleetService);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Customer/5
        [HttpPut]
        public IHttpActionResult UpdateFleetService(int id, [FromBody]FleetService fleetService)
        {
            try
            {
                var fleetServiceModel = _fleetServiceRepo.Get(id);
                if (fleetServiceModel == null)
                {
                    return NotFound();
                }
                fleetServiceModel.ServiceName = fleetService.ServiceName;
                fleetServiceModel.ServiceType = fleetService.ServiceType;
                fleetServiceModel.UnitOfMeasurement = fleetService.UnitOfMeasurement;
                fleetServiceModel.LastModifiedBy = fleetService.LastModifiedBy;
                fleetServiceModel.StatusId = fleetService.StatusId;
                fleetServiceModel.LastModifiedDate = DateTime.Now;
                _fleetServiceRepo.Update(fleetServiceModel);
                return Ok(fleetServiceModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult FleetServiceGetKeyPair(CompanyBusinessUntiInfoViewModel model)
        {
            try
            {
                var keyPairValues = _fleetServiceRepo.GetKeyPairValue();
                return Ok(keyPairValues);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPost]
        public IHttpActionResult GetByIdCollection(List<int> model)
        {
            try
            {
                var keyPairValues = _fleetServiceRepo.GetByIdCollection(model);
                var fleetServices = new List<FleetServiceViewModel>();
                foreach(var item in keyPairValues)
                {
                    fleetServices.Add(new FleetServiceViewModel
                    {
                        Id=item.Id,
                        ServiceName=item.ServiceName,
                        ServiceType=item.ServiceType,
                        UnitOfMeasurement=item.UnitOfMeasurement
                    });
                }
                return Ok(fleetServices);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
