﻿using GENXAPI.Repisitory.Model;
using System.Collections.Generic;

namespace GENXAPI.Repisitory
{
    public interface IRegionRepository: IRepository<Region>
    {
        IList<DropdownListDto> GetKeyPairValue(int CompanyId, int BusinessUnitId);
    }
}
