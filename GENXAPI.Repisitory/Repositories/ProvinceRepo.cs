using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class ProvinceRepo : GenericCRUD<Province>
    {

        public IList<Province> GetAllActive()
        {
            var result = GetAll();
            return result.ToList();
        }

        public IList<DropdownListDto> GetKeyPairValue(int BusinessUnitId)
        {
            var result = Find(m => m.StatusId == (byte)Status.Active && m.BusinessUnitId == BusinessUnitId).Select(r =>
            new DropdownListDto
            {
                Value = r.Id.ToString(),
                Text = r.Name
            });
            return result.ToList();
        }
    }
}
