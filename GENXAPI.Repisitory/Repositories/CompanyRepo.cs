using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GENXAPI.Utilities;

namespace GENXAPI.Repisitory
{
    public class CompanyRepo : GenericCRUD<Company>
    {
        public IList<Company> GetAllActive()
        {
            var result = Find(m => m.StatusId == (byte)Status.Active);
            return result.ToList();
        }

        public IList<DropdownListDto> GetKeyPairValue()
        {
            var result = Find(m => m.StatusId == (byte)Status.Active).Select(r =>
            new DropdownListDto
            {
                Value = r.CompanyId.ToString(),
                Text = r.Name
            });
            return result.ToList();
        }
    }
}
