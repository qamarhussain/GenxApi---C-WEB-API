using GENXAPI.Repisitory.Core;
using System;

namespace GENXAPI.Repisitory
{
    public interface IUnitOfWork : IDisposable
    {
        ITenderRepository Tenders { get; }
        ITenderDetailRepository TenderDetails { get; }
        ITenderChildRepository TenderChilds { get; }
        ICustomerRepository Customers { get; }
        IRegionRepository Region { get; }
        IVendorQuotationRepository VendorQuotation { get; }
        IVendorQuotationDetailRepository VendorQuotationDetail { get; }
        IVendorQuotationChildRepository VendorQuotationChild { get; }
        IContractCancelationRepository ContractCancelation { get; }
        ICustomerBusinessLineRepository CustomerBusinessLine { get; }


        int SaveChanges();
    }
}
