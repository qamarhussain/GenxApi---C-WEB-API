using GENXAPI.Repisitory.Model;
using System.Collections.Generic;
namespace GENXAPI.Repisitory.Core
{
    public interface ICityRepository: IRepository<City>
    {
        IList<DropdownListDto> GetKeyPairValue();
    }
}
