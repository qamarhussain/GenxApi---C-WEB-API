﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GENXAPI.Api.Models
{
    public class CompanyBusinessUntiInfoViewModel
    {
        public int CompanyId { get; set; }
        public int BusinessUnitId { get; set; }
        public int ProvinceId { get; set; }
        public int CustomerId { get; set; }
    }
}