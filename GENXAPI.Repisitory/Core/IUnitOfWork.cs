using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public interface IUnitOfWork : IDisposable
    {
        ITenderRepository Tenders { get; }
        ITenderDetailRepository TenderDetails { get; }
        ITenderChildRepository TenderChilds { get; }
        ICustomerRepository Customers { get; }

        IVendorQuotationRepository VendorQuotation { get; }
        IVendorQuotationDetailRepository VendorQuotationDetail { get; }
        IVendorQuotationChildRepository VendorQuotationChild { get; }
        IContractCancelationRepository ContractCancelation { get; }
        ICustomerBusinessLineRepository CustomerBusinessLine { get; }


        int SaveChanges();
    }
}
