using GENXAPI.Repisitory;
using GENXAPI.Repisitory.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GENXAPI.Api.Controllers
{
    [Authorize]
    public class DashboardController : ApiController
    {
        #region Private variables.
        protected readonly ModuleFormRepo _moduleFormRepo = new ModuleFormRepo();
        protected readonly CompanyRepo _companyRepo = new CompanyRepo();
        protected readonly BusinessUnitRepo _businessUnitKeyPair = new BusinessUnitRepo();
        protected readonly FinancialYearDefinationRepo _financialYearRepo = new FinancialYearDefinationRepo();
        #endregion

        [HttpGet]
        public IHttpActionResult GetAllModule()
        {
            try
            {
                var result = _moduleFormRepo.GetAll().OrderBy(x=>x.OrderBy).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        public IHttpActionResult GetStartupKeyPair()
        {
            try
            {
                var companyKairPair = _companyRepo.GetKeyPairValue().ToList();
                var businessUnitKeyPair = _businessUnitKeyPair.GetKeyPairValue().ToList();
                var financialYearKeyPair = _financialYearRepo.GetKeyPairValue().ToList();
                var startupKeyPairModel = new StartupKeyPairViewModel()
                {
                    CompanyKairPair = companyKairPair,
                    BusinessUnitKeyPair = businessUnitKeyPair,
                    FinancialYearKeyPair = financialYearKeyPair
                };
                return Ok(startupKeyPairModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
           

        }
    }
}
