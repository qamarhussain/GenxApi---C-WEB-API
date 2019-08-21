﻿
using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Entities db;

        public UnitOfWork()
        {
            db = new Entities();
            db.Configuration.LazyLoadingEnabled = false;
        }

        private ITenderRepository _Tenders;
        public ITenderRepository Tenders
        {
            get
            {
                if (this._Tenders == null)
                {
                    this._Tenders = new TenderRepository(db);
                }
                return this._Tenders;
            }
        }

        private ITenderDetailRepository _tenderDetails;
        public ITenderDetailRepository TenderDetails
        {
            get
            {
                if (this._tenderDetails == null)
                {
                    this._tenderDetails = new TenderDetailRepository(db);
                }
                return this._tenderDetails;
            }
        }

        private ITenderChildRepository _tenderChilds;
        public ITenderChildRepository TenderChilds
        {
            get
            {
                if(this._tenderChilds == null)
                {
                    this._tenderChilds = new TenderChildRepository(db);
                }
                return this._tenderChilds;
            }
          
        }

        private ICustomerRepository _customers;
        public ICustomerRepository Customers
        {
            get
            {
                if(this._customers == null)
                {
                    this._customers = new CustomerRepository(db);
                }
                return this._customers;
            }
        }

        private IVendorQuotationRepository _vendorQuotation;

        public IVendorQuotationRepository VendorQuotation
        {
            get
            {
                if (this._vendorQuotation == null)
                {
                    this._vendorQuotation = new VendorQuotationRepository(db);
                }
                return this._vendorQuotation;
            }
        }

        private IVendorQuotationDetailRepository _vendorQuotationDetail;
        public IVendorQuotationDetailRepository VendorQuotationDetail
        {
            get
            {
                if (this._vendorQuotationDetail == null)
                {
                    this._vendorQuotationDetail = new VendorQuotationDetailRepository(db);
                }
                return this._vendorQuotationDetail;
            }
        }

        private IVendorQuotationChildRepository _vendorQuotationChild;
        public IVendorQuotationChildRepository VendorQuotationChild
        {
            get
            {
                if (this._vendorQuotationChild == null)
                {
                    this._vendorQuotationChild = new VendorQuotationChildRepository(db);
                }
                return this._vendorQuotationChild;
            }
        }

        private IContractCancelationRepository _contractCancelation;
        public IContractCancelationRepository ContractCancelation
        {
            get
            {
                if (this._contractCancelation == null)
                {
                    this._contractCancelation = new ContractCancelationRepository(db);
                }
                return this._contractCancelation;
            }
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
