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

        public IList<DropdownListDto> GetKeyPairValue(int TenderId, int CompanyId, int BusinessUnitId)
        {

            var result = Find(m => m.TenderId == TenderId && m.CompanyId == CompanyId && m.BusinessUnitId == BusinessUnitId).Select(r =>
           new DropdownListDto
           {
               VendorId = r.VendorId.ToString(),
               Text = r.VendorName,
               Value = r.VendorQuotationId.ToString()
              
           });
            return result.ToList();
        }
    }
}