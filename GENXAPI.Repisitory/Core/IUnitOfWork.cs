﻿using GENXAPI.Repisitory.Core;
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
        IVendorQuotationChildRepository VendorQuotationChild { get; }
        IContractCancelationRepository ContractCancelation { get; }
        ICustomerBusinessLineRepository CustomerBusinessLine { get; }
        ICityRepository City { get; }
        IJobExecutedTrackingRepository JobExecutedTracking { get; }
        IRegionalOfficeRepository RegionalOffice { get; }
        IJobRepository Job { get; }
        IJobChildRepository JobChild { get; }
        IJobQuotationApprovalRepository JobQuotationApproval { get; }

        IExecutedJobRepository ExecutedJob { get; }
        IFileRepository File { get;}
        ITenderWiseVendorRepository TenderWiseVendor { get; }
        int SaveChanges();
    }
}
