using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GENXAPI.Api.Controllers
{
    [Authorize]
    public class VendorQuotationController : ApiController
    {
        [HttpPost]
        public IHttpActionResult CreateVendorQuotation()
        {
            return Ok();
        }
    }
}
