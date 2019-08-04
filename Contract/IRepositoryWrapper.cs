namespace GENXAPI.Contract
{
    public interface IRepositoryWrapper
    {
        ITenderRepository Tender { get; }
        ITenderDetailRepository TenderDetail { get; }
        ITenderChildRepository TenderChild { get; }
        ICustomerRepository Customer { get; }
        void Save();
    }
}
