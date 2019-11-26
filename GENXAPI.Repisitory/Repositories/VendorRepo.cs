﻿using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory.Repositories
{
    public class VendorRepo : GenericCRUD<AML_Vendor>
    {
        public IList<AML_Vendor> GetAllActive()
        {
            var result = GetAll();
            return result.ToList();
        }
        public IList<DropdownListDto> GetKeyPairValue()
        {
            return null;
        }
        
    }
   
}
