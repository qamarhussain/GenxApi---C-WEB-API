using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public interface IRegionalOfficeRepository : IRepository<RegionalOffice>
    {
        List<DropdownListDto> GetKeyPair(int CompanyId, int BusinessUnitId);
    }
}
