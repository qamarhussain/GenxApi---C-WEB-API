using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GENXAPI.Api.Models
{
    public class VendorViewModel
    {
        public List<DropdownListDto> CurrencyKeyPairValue { get; set; }
        public List<DropdownListDto> VendorOrgTypeKeyPairValue { get; set; }
        public List<DropdownListDto> VendorBusinessNatureKeyPairValue { get; set; }
    }
}