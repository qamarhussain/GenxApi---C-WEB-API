using GENXAPI.Repisitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GENXAPI.Api.Models;
using GENXAPI.Api.Attributes;

namespace GENXAPI.Api.Controllers
{
    [Authorize]
    [CustomExceptionFilter]

    public class RegionalOfficeController : ApiController
    {
        IUnitOfWork _unitOfWork;
        public RegionalOfficeController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IHttpActionResult GetAllRegionalOffices(CompanyBusinessUntiInfoViewModel model)
        {
            try
            {
                var data = _unitOfWork.RegionalOffice.AllIncluding(d=>d.City).Where(x => x.CompanyId == model.CompanyId && x.BusinessUnitId == model.BusinessUnitId).ToList();
                return Ok(data);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult GetKeyPair(CompanyBusinessUntiInfoViewModel model)
        {
            return Ok(_unitOfWork.RegionalOffice.GetKeyPair(model.CompanyId, model.BusinessUnitId));
        }

    }
}
