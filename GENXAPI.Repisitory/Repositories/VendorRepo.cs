using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory.Repositories
{
    public class VendorRepo : GenericCRUD<Vendor>
    {
        public IList<Vendor> GetAllActive()
        {
            var result = GetAll();
            return result.ToList();
        }
        public IList<DropdownListDto> GetKeyPairValue(int CompanyId, int BusinessUnitId)
        {
            var result = Find(m => m.StatusId == (byte)Status.Active && m.CompanyId == CompanyId).Select(r =>
         new DropdownListDto
         {
             Value = r.VendorId.ToString(),
             Text = r.VendorName
         });
            return result.ToList();
        }
        
    }
   
}
