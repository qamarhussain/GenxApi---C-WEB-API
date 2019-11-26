using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class VendorOrgTypeRepo : GenericCRUD<AML_VendorsOrgType>
    {

        public IList<AML_VendorsOrgType> GetAllActive()
        {
            var result = GetAll();
            return result.ToList();
        }

        public IList<DropdownListDto> GetKeyPairValue()
        {
            var result = Find(m => m.StatusId == (byte)Status.Active).Select(r =>
           new DropdownListDto
           {
               Value = r.Id.ToString(),
               Text = r.OrgTypeName
           });
            return result.ToList();
        }
    }
}
