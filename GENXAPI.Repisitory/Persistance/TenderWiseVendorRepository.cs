using GENXAPI.Repisitory.Core;
using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory.Persistance
{
    public class TenderWiseVendorRepository : Repository<ViewTenderWiseVendor>, ITenderWiseVendorRepository
    {
        public Entities context
        {
            get
            {
                return db as Entities;
            }
        }

        public TenderWiseVendorRepository(Entities _db)
            : base(_db)
        {

        }
    }
}
