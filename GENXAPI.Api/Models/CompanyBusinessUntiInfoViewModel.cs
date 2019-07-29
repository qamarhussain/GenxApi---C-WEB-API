using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GENXAPI.Api.Models
{
    public class CompanyBusinessUntiInfoViewModel
    {
        public string CompanyId { get; set; }
        public string BusinessUnitId { get; set; }
        public int? ProvinceId { get; set; }
    }
}