using GENXAPI.Repisitory.Model;

namespace GENXAPI.Contract
{
    public class TenderDetailRepository : RepositoryBase<TenderDetail>, ITenderDetailRepository
    {
        public TenderDetailRepository(Entities repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
