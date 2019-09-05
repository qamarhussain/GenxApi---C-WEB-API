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
    public class CityController : ApiController
    {
        IUnitOfWork _unitOfWork;
        public CityController()
        {
            _unitOfWork = new UnitOfWork();
            
        }
        protected readonly CityRepo _cityRepo = new CityRepo();
        // GET: api/Customer
        [HttpGet]
        public IHttpActionResult GetAllCities()
        {
            try
            {
                //var result = _cityRepo.AllIncluding(e => e.Province, a => a.Region).ToList();
               var result = _unitOfWork.City.AllIncluding(y => y.Province, a => a.Region).ToList(); 
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // GET: api/Customer/5
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var city = _cityRepo.Get(id);
                if (city == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(city);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Customer
        [HttpPost]
        public IHttpActionResult CreateCity([FromBody]City city)
        {
            try
            {
                city.StatusId = (byte)Status.Active;
                city.CreatedOn = DateTime.Now;
                city.LastModifiedDate = DateTime.Now;
                _cityRepo.Create(city);
                return Ok(city);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Customer/5
        [HttpPut]
        public IHttpActionResult UpdateCity(int id, [FromBody]City city)
        {
            try
            {
                var cityModel = _cityRepo.Get(id);
                if (cityModel == null)
                {
                    return NotFound();
                }
                cityModel.LastModifiedDate = DateTime.Now;
                cityModel.LastModifiedBy = cityModel.LastModifiedBy;
                cityModel.ProvinceId = city.ProvinceId;
                cityModel.RegionId = city.RegionId;
                cityModel.Name = city.Name;
                cityModel.StatusId = city.StatusId;

                _cityRepo.Update(cityModel);
                return Ok(cityModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // DELETE: api/Customer/5
        [HttpDelete]
        public IHttpActionResult DeleteCity(int id)
        {

            try
            {
                var cityModel = _cityRepo.Get(id);
                if (cityModel == null)
                {
                    return NotFound();
                }

                _cityRepo.Delete(id);
                return Ok(cityModel);
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
                var keyPairValues = _cityRepo.GetKeyPairValue(model.ProvinceId);
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
                var keyPairValues = _cityRepo.GetByIdCollection(model);
                var cities = new List<CityViewModel>();
                foreach(var item in keyPairValues)
                {
                    cities.Add(new CityViewModel
                    {
                        Id=item.CityId,
                        Name=item.Name
                    });
                }
                
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpPost]
        public IHttpActionResult GetCitiesListByRegionId(CompanyBusinessUntiInfoViewModel model)
        {
            try
            {
                var keyPairValues = _unitOfWork.City.GetKeyPairValue(model.RegionId);
                return Ok(keyPairValues);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        public IHttpActionResult GetCitiesListForDropdown()
        {
            try
            {
                var keyPairValues = _unitOfWork.City.GetKeyPairValue();
                return Ok(keyPairValues);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }


    }
}
