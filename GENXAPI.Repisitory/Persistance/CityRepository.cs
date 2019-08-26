using GENXAPI.Repisitory.Core;
using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;
using System.Collections.Generic;
using System.Linq;


namespace GENXAPI.Repisitory.Persistance
{
    public class CityRepository: Repository<City>, ICityRepository
    {
        public Entities context
        {
            get
            {
                return db as Entities;
            }
        }

        public CityRepository(Entities _db)
            : base(_db)
        {

        }

        public IList<DropdownListDto> GetKeyPairValue()
        {
            var result = Find(m => m.StatusId == (byte)Status.Active).Select(r =>
            new DropdownListDto
            {
                Value = r.CityId.ToString(),
                Text = r.Name
            });
            return result.ToList();
        }
    }
}
