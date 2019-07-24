using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class FinancialYearDefinationRepo : GenericCRUD<FinancialYearDefination>
    {
        public IList<DropdownListDto> GetKeyPairValue()
        {
            var result = Find(m => m.StatusId == (byte)Status.Active).Select(r =>
            new DropdownListDto
            {
                Value = r.CompanyId.ToString(),
                Text = r.FYearTitle,
                ParentReferenceId = r.CompanyId.ToString()
            });
            return result.ToList();
        }

    }
}
