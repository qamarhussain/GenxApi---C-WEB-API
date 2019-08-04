using GENXAPI.Repisitory.Model;

namespace GENXAPI.Contract
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private Entities _repoContext;
        private ICustomerRepository _customer;
        private ITenderRepository _tender;
        private ITenderDetailRepository _tenderDetail;
        private ITenderChildRepository _tenderChild;

        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_repoContext);
                }

                return _owner;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_repoContext);
                }

                return _account;
            }
        }

        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_repoContext);
                }

                return _customer;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
