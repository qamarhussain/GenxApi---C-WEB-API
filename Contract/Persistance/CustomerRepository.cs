using GENXAPI.Repisitory.Model;

namespace GENXAPI.Contract
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(Entities repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
