using GENXAPI.Api.Attributes;
using GENXAPI.Api.Models;
using GENXAPI.Repisitory;
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
        public IHttpActionResult CreateJobExecution(ExecutedJobCreateViewModel model)
        {
            model.itemCodeList.ForEach(x => x.CreatedOn = DateTime.Now);
            model.itemCodeList.ForEach(x => x.LastModifiedDate = DateTime.Now);
            _unitOfWork.ExecutedJob.AddRange(model.itemCodeList);
            _unitOfWork.SaveChanges();
            return Ok(model);
        }



    }
}
