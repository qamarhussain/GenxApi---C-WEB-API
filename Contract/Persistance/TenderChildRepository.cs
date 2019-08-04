using GENXAPI.Repisitory.Model;
namespace GENXAPI.Contract
{
    public class TenderChildRepository : RepositoryBase<TenderChild>, ITenderChildRepository
    {
        public TenderChildRepository(Entities repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
