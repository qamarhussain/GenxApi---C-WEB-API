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
    public class TenderController : ApiController
    {
        protected readonly TenderRepo _tenderRepo = new TenderRepo();
        // GET: api/Customer
        [HttpGet]
        public IHttpActionResult GetAllTenders()
        {
            try
            {
                var result = _tenderRepo.GetAll().ToList();
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
                var tender = _tenderRepo.Get(id);
                if (tender == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(tender);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Customer
        [HttpPost]
        public IHttpActionResult CreateTender([FromBody]Tender tender)
        {
            try
            {
                tender.StatusId = (byte)Status.Active;
                tender.IssuanceDate = DateTime.Now;
                tender.LastModifiedDate = DateTime.Now;

                _tenderRepo.Create(tender);
                return Ok(tender);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Customer/5
        [HttpPut]
        public IHttpActionResult UpdateTender(int id, [FromBody]Tender tender)
        {
            try
            {
                var tenderModel = _tenderRepo.Get(id);
                if (tenderModel == null)
                {
                    return NotFound();
                }
                tenderModel.LastModifiedBy = tender.LastModifiedBy;
                tenderModel.LastModifiedDate = tender.LastModifiedDate;

                _tenderRepo.Update(tenderModel);
                return Ok(tenderModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // DELETE: api/Customer/5
        [HttpDelete]
        public IHttpActionResult DeleteTender(int id)
        {

            try
            {
                var tenderModel = _tenderRepo.Get(id);
                if (tenderModel == null)
                {
                    return NotFound();
                }

                _tenderRepo.Delete(id);
                return Ok(tenderModel);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
