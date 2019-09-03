using GENXAPI.Repisitory.Model;
using System.Collections.Generic;
namespace GENXAPI.Repisitory
{
    public interface ICityRepository: IRepository<City>
    {
        IList<DropdownListDto> GetKeyPairValue(int regionId);
        IList<DropdownListDto> GetKeyPairValue();
    }
}
