﻿using GENXAPI.Api.Attributes;
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
            try
            {
                model.CreatedOn = DateTime.Now;
                model.LastModifiedDate = DateTime.Now;
                _unitOfWork.ExecutedJob.Add(model);
                var jobChild = _unitOfWork.JobChild.Find(x => x.ItemCode == model.ItemCode && x.JobId == model.JobId).FirstOrDefault();
                if (jobChild != null)
                {
                        jobChild.IsExecuted = (byte)TenderChildStatus.JobExecuted;
                        _unitOfWork.JobChild.Update(jobChild);
                }
                var tenderChild = _unitOfWork.TenderChilds.Find(x => x.ItemCode == model.ItemCode && x.CustomerId == model.CustomerId && x.TenderId == model.ContractId).FirstOrDefault();
                if (tenderChild != null)
                {
                        tenderChild.IsJobExecuted = (byte)TenderChildStatus.JobExecuted;
                        _unitOfWork.TenderChilds.Update(tenderChild);
                }
                _unitOfWork.SaveChanges();
                return Ok(model);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
          
        }



    }
}
