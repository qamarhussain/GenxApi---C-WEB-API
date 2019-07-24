using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class UnitRepo : GenericCRUD<Unit>
    {

        public IList<Unit> GetAllActive()
        {
            var result = GetAll();
            return result.ToList();
        }

        public IList<DropdownListDto> GetKeyPairValue()
        {
            return null;
        }
    }
}
