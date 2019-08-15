using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public Entities context
        {
            get
            {
                return db as Entities;
            }
        }

        public CustomerRepository(Entities _db)
            : base(_db)
        {

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