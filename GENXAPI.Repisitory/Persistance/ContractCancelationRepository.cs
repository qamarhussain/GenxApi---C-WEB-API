using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class ContractCancelationRepository : Repository<ContractCancelation>, IContractCancelationRepository
    {
        public Entities context
        {
            get
            {
                return db as Entities;
            }
        }

        public ContractCancelationRepository(Entities _db)
            : base(_db)
        {

        }
    }
}
