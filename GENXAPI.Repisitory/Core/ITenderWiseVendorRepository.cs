using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory.Core
{
    public interface ITenderWiseVendorRepository : IRepository<ViewTenderWiseVendor>
    {
        IList<DropdownListDto> GetKeyPairValue(int TenderId, int CompanyId, int BusinessUnitId);
    }
}
