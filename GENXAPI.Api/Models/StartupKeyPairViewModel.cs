using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GENXAPI.Api
{
    public class StartupKeyPairViewModel
    {
        public List<DropdownListDto> CompanyKairPair { get; set; }
        public List<DropdownListDto> BusinessUnitKeyPair { get; set; }
        public List<DropdownListDto> FinancialYearKeyPair { get; set; }
    }
}