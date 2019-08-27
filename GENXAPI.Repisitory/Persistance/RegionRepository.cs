using GENXAPI.Repisitory.Core;
using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;
using System.Collections.Generic;
using System.Linq;
namespace GENXAPI.Repisitory
{
    public class RegionRepository: Repository<Region>, IRegionRepository
    {
        public Entities context
        {
            get
            {
                return db as Entities;
            }
        }

        public RegionRepository(Entities _db)
            : base(_db)
        {

        }

        public IList<DropdownListDto> GetKeyPairValue(int CompanyId, int BusinessUnitId)
        {
            var result = Find(m => m.StatusId == (byte)Status.Active && m.CompanyId == CompanyId && m.BusinessUnitId == BusinessUnitId).Select(r =>
            new DropdownListDto
            {
                Value = r.RegionId.ToString(),
                Text = r.Name
            });
            return result.ToList();
        }

        public IList<DropdownListDto> GetKeyPairValue(int ProvinceId)
        {
            var result = Find(m => m.StatusId == (byte)Status.Active && m.ProvinceId == ProvinceId).Select(r =>
            new DropdownListDto
            {
                Value = r.RegionId.ToString(),
                Text = r.Name
            });
            return result.ToList();
        }

    }
}
