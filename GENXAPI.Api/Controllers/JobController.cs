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
    public class JobController : ApiController
    {
        IUnitOfWork _unitOfWork;
        public JobController()
        {
            _unitOfWork = new UnitOfWork();
        }

        [HttpPost]
        public IHttpActionResult GetAllJobOrders(CompanyBusinessUntiInfoViewModel model)
        {
            var date = _unitOfWork.Job.AllIncluding(a => a.JobChilds, b => b.Tender.Customer, c => c.Tender.TenderChilds).Where(x => x.CompanyId == model.CompanyId && x.BusinessUnitId == model.BusinessUnitId).ToList();
            return Ok(date);
        }

        // Used to get contract to make a job.
        [HttpPost]
        public IHttpActionResult GetContractForJob(CompanyBusinessUntiInfoViewModel model)
        {
            try
            {
                var keyPairValues = _unitOfWork.Tenders.GetContractKeyPairForJob(model.CustomerId);
                return Ok(keyPairValues);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
