using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class RegionalOfficeRepository : Repository<RegionalOffice>, IRegionalOfficeRepository
    {
        public Entities context
        {
            get
            {
                return db as Entities;
            }
        }

        public RegionalOfficeRepository(Entities _db)
            : base(_db)
        {

        }

        public List<DropdownListDto> GetKeyPair(int CompanyId, int BusinessUnitId)
        {
            var result = Find(m => m.StatusId == (byte)Status.Active && m.CompanyId == CompanyId && m.BusinessUnitId == BusinessUnitId).Select(r =>
        new DropdownListDto
        {
            Value = r.Id.ToString(),
            Text = r.OfficeName
        });
            return result.ToList();
        }
    }
}
