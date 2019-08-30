using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class CityRepo : GenericCRUD<City>
    {

        public IList<City> GetAllActive()
        {
            var result = GetAll();
            return result.ToList();
        }

        public IList<DropdownListDto> GetKeyPairValue(int? ProvinceId)
        {
            var result = new List<DropdownListDto>();
            if (ProvinceId != 0 && ProvinceId != null)
            {
                result = Find(m => m.StatusId == (byte)Status.Active && m.ProvinceId == ProvinceId).Select(r =>
         new DropdownListDto
         {
             Value = r.CityId.ToString(),
             Text = r.Name
         }).ToList();
            }
            else
            {
                result = Find(m => m.StatusId == (byte)Status.Active).Select(r =>
         new DropdownListDto
         {
             Value = r.CityId.ToString(),
             Text = r.Name,
             ParentReferenceId=r.ProvinceId.ToString()
         }).ToList();
            }

            return result.ToList();
        }

        public IList<City> GetByIdCollection(List<int> ids)
        {
            return GetAll().Where(x => ids.Contains(x.CityId)).ToList();
        }

    }

   

}
