using GENXAPI.Api.Models;
using GENXAPI.Repisitory;
using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;
using System;
using System.Linq;
using System.Web.Http;

namespace GENXAPI.Api.Controllers
{
    [Authorize]
    public class RegionController : ApiController
    {
        IUnitOfWork _unitOfWork;
        public RegionController()
        {
            _unitOfWork = new UnitOfWork();
        }
        [HttpGet]
        public IHttpActionResult GetAllRegions()
        {
            try
            {
                var result = _unitOfWork.Region.AllIncluding(e => e.Province).ToList();
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }

        }

        // GET: api/region/5
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var region = _unitOfWork.Region.Get(id);
                if (region == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(region);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/region
        [HttpPost]
        public IHttpActionResult CreateRegion([FromBody]Region region)
        {
            try
            {
                region.StatusId = (byte)Status.Active;
                region.CreatedOn = DateTime.Now;
                region.LastModifiedDate = DateTime.Now;
                _unitOfWork.Region.Add(region);
                _unitOfWork.SaveChanges();
                return Ok(region);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/region/5
        [HttpPut]
        public IHttpActionResult UpdateRegion(int id, [FromBody]Region region)
        {
            try
            {
                var regionModel = _unitOfWork.Region.Get(id);
                if (regionModel == null)
                {
                    return NotFound();
                }
                regionModel.LastModifiedDate = DateTime.Now;
                regionModel.LastModifiedBy = regionModel.LastModifiedBy;
                regionModel.ProvinceId = region.ProvinceId;
                regionModel.Name = region.Name;
                regionModel.StatusId = region.StatusId;

                _unitOfWork.Region.Update(regionModel);
                _unitOfWork.SaveChanges();
                return Ok(regionModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // DELETE: api/region/5
        [HttpDelete]
        public IHttpActionResult DeleteRegion(int id)
        {

            try
            {
                var regionModel = _unitOfWork.Region.Get(id);
                if (regionModel == null)
                {
                    return NotFound();
                }

                _unitOfWork.Region.Remove(id);
                _unitOfWork.SaveChanges();
                return Ok(regionModel);
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
                var keyPairValues = _unitOfWork.Region.GetKeyPairValue(Convert.ToInt32(model.CompanyId), Convert.ToInt32(model.BusinessUnitId));
                return Ok(keyPairValues);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

    }
}
