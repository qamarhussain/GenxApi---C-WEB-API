using GENXAPI.Repisitory.Model;
using System.Collections.Generic;

namespace GENXAPI.Repisitory
{
    public interface ITenderRepository : IRepository<Tender>
    {
         IList<DropdownListDto> GetContractKeyPair(int CompanyId, int BusinessUnitId, int CustomerId);
    }
}
