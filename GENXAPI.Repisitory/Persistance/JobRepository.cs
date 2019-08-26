using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public Entities context
        {
            get
            {
                return db as Entities;
            }
        }

        public JobRepository(Entities _db)
            : base(_db)
        {

        }
    }
}
