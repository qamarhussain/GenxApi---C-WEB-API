using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class TenderRepo : GenericCRUD<Tender>
    {

        public IList<Tender> GetAllActive()
        {
            var result = GetAll();
            return result.ToList();
        }

        public IList<DropdownListDto> GetKeyPairValue(int? customerId)
        {
            var result = Find(m => m.StatusId == (byte)Status.Active  && m.CustomerId == customerId).Select(r =>
            new DropdownListDto
            {
                Value = r.Id.ToString(),
                Text = r.TenderNo
            });
            return result.ToList();

        }
    }
}
