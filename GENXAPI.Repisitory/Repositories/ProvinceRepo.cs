﻿using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class ProvinceRepo : GenericCRUD<AML_Province>
    {

        public IList<AML_Province> GetAllActive()
        {
            var result = Find(m => m.StatusId == (byte)Status.Active);
            return result.ToList();
        }

        public IList<DropdownListDto> GetKeyPairValue(int CompanyId, int BusinessUnitId)
        {
            var result = Find(m => m.StatusId == (byte)Status.Active && m.CompanyId == CompanyId && m.BusinessUnitId == BusinessUnitId).Select(r =>
            new DropdownListDto
            {
                Value = r.Id.ToString(),
                Text = r.Name
            });
            return result.ToList();
        }
    }
}
