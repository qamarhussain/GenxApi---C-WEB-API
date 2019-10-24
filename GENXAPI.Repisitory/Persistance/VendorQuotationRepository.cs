using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class VendorQuotationRepository : Repository<VendorQuotation>, IVendorQuotationRepository
    {
        public Entities context
        {
            get
            {
                return db as Entities;
            }
        }

        public VendorQuotationRepository(Entities _db)
            : base(_db)
        {

        }

        public IList<DropdownListDto> GetKeyPairValue(int TenderId)
        {



            var data = GetAll().ToList();



            var result = Find(m => m.StatusId == (byte)Status.Active && m.TenderId == TenderId).Select(r =>
           new DropdownListDto
           {
               Value = r.VendorId.ToString(),
               Text = r.Vendor.VendorName
           });
            return result.ToList();
            //var sql = "SELECT Vendor.VendorId, VendorName " +
            //            "FROM Vendor " +
            //            "INNER JOIN VendorQuotation ON VendorQuotation.VendorId = Vendor.VendorId " +
            //            "WHERE VendorQuotation.TenderId = @0";
            //return db.Database.

        }
    
    }
}
