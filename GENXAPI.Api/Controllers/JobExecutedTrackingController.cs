using GENXAPI.Api.Attributes;
using GENXAPI.Repisitory;
using GENXAPI.Repisitory.Model;
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
    public class JobExecutedTrackingController : ApiController
    {
        IUnitOfWork _unitOfWork;
        public JobExecutedTrackingController()
        {
            _unitOfWork = new UnitOfWork();
        }

        [HttpPost]
        public IHttpActionResult CreateJobExecutedTracking(JobExecutedTracking model)
        {
            try
            {
                model.CreatedOn = DateTime.Now;
                model.LastModifiedDate = DateTime.Now;
                _unitOfWork.JobExecutedTracking.Add(model);
           
                _unitOfWork.SaveChanges();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
