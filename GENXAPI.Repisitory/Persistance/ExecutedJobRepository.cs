using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class ExecutedJobRepository : Repository<ExecutedJob>, IExecutedJobRepository
    {
        public Entities context
        {
            get
            {
                return db as Entities;
            }
        }

        public ExecutedJobRepository(Entities _db)
            : base(_db)
        {

        }

    }
}
