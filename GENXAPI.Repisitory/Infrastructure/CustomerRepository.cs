using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public Entities context
        {
            get
            {
                return db as Entities;
            }
        }

        public CustomerRepository(Entities _db)
            : base(_db)
        {

        }

    }
}