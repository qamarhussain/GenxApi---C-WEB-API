using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class VehicleRepo : GenericCRUD<AML_Vehicles>
    {

        public IList<AML_Vehicles> GetAllActive()
        {
            var result = GetAll();
            return result.ToList();
        }

        public IList<DropdownListDto> GetKeyPairValue(int CompanyId, int BusinessUnitId)
        {
            var result = Find(m => m.StatusId == (byte)Status.Active && m.CompanyId == CompanyId && m.BusinessUnitId == BusinessUnitId).Select(r =>
            new DropdownListDto
            {
                Value = r.Id.ToString(),
                Text = r.Title + "-"+ r.Weight
            });
            return result.ToList();
        }
    }
}
