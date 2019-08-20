using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class VendorQuotationDetailRepository : Repository<VendorQuotationDetail>, IVendorQuotationDetailRepository
    {
        public Entities context
        {
            get
            {
                return db as Entities;
            }
        }

        public VendorQuotationDetailRepository(Entities _db)
            : base(_db)
        {

        }
    }
}
