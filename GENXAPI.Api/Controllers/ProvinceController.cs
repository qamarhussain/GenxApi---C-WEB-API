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
    public class ProvinceController : ApiController
    {
        protected readonly ProvinceRepo _provinceRepo = new ProvinceRepo();
        // GET: api/Customer
        [HttpGet]
        public IHttpActionResult GetAllProvinces()
        {
            try
            {
                var result = _provinceRepo.GetAll().ToList();
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
                var province = _provinceRepo.Get(id);
                if (province == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(province);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Customer
        [HttpPost]
        public IHttpActionResult CreateProvince([FromBody]Province province)
        {
            try
            {
                province.StatusId = (byte)Status.Active;
                province.CreatedOn = DateTime.Now;
                province.LastModifiedDate = DateTime.Now;
                _provinceRepo.Create(province);
                return Ok(province);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Customer/5
        [HttpPut]
        public IHttpActionResult UpdateProvince(int id, [FromBody]Province province)
        {
            try
            {
                var provinceModel = _provinceRepo.Get(id);
                if (provinceModel == null)
                {
                    return NotFound();
                }
                provinceModel.LastModifiedDate = DateTime.Now;
                provinceModel.LastModifiedBy = provinceModel.LastModifiedBy;
                provinceModel.Abbreviation = province.Abbreviation;
                provinceModel.CountryId = province.CountryId;
                provinceModel.Name = province.Name;
                provinceModel.BusinessUnitId = province.BusinessUnitId;
                provinceModel.StatusId = province.StatusId;

                _provinceRepo.Update(provinceModel);
                return Ok(provinceModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // DELETE: api/Customer/5
        [HttpDelete]
        public IHttpActionResult DeleteProvince(int id)
        {

            try
            {
                var provinceModel = _provinceRepo.Get(id);
                if (provinceModel == null)
                {
                    return NotFound();
                }

                _provinceRepo.Delete(id);
                return Ok(provinceModel);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }


        [HttpGet]
        public IHttpActionResult GetKeyPair(int id)
        {
            try
            {
                var keyPairValues = _provinceRepo.GetKeyPairValue(id);
                return Ok(keyPairValues);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

    }
}
