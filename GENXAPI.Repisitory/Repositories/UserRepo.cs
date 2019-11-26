using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class UserRepo : GenericCRUD<AML_Users>
    {
        public IList<AML_Users> GetAllActive()
        {
            var result = GetAll();
            return result.ToList();
        }
        public IList<DropdownListDto> GetKeyPairValue()
        {
            return null;
        }

        public AML_Users GetUser(string username, string password)
        {
           return Find(x => x.UserName == username && x.Password == password).FirstOrDefault();
        }
    }
}
