using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class BusinessUnitRepo : GenericCRUD<BusinessUnit>
    {
        public IList<BusinessUnit> GetAllActive()
        {
            var result = Find(m => m.StatusId == (byte)Status.Active);
            return result.ToList();
        }

        public IList<DropdownListDto> GetKeyPairValue()
        {
            var result = Find(m => m.StatusId == (byte)Status.Active).Select(r =>
            new DropdownListDto
            {
                Value = r.BusinessUnitId.ToString(),
                Text = r.Name,
                ParentReferenceId = r.CompanyId.ToString()
            });
            return result.ToList();
        }
    }
}

