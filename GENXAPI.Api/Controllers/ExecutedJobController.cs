using GENXAPI.Api.Attributes;
using GENXAPI.Api.Models;
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
    public class ExecutedJobController : ApiController
    {
        IUnitOfWork _unitOfWork;
        public ExecutedJobController()
        {
            _unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        public IHttpActionResult GetAllExecutedJobs()
        {
            var data = _unitOfWork.ExecutedJob.GetAll();
            return Ok(data);
        }

        [HttpPost]
        public IHttpActionResult CreateJobExecution(ExecutedJob model)
        {
            model.CreatedOn = DateTime.Now;
            model.LastModifiedDate = DateTime.Now;
            _unitOfWork.ExecutedJob.Add(model);
            _unitOfWork.SaveChanges();
            return Ok(model);
        }



    }
}
