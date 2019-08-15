using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IList<DropdownListDto> GetKeyPairValue(int CompanyId, int BusinessUnitId);
    }
}
