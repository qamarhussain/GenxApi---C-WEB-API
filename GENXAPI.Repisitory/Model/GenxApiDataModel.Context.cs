﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GENXAPI.Repisitory.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<ContractCancelation> ContractCancelations { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CustomerBusinessLine> CustomerBusinessLines { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<FinancialYearDefination> FinancialYearDefinations { get; set; }
        public virtual DbSet<FleetService> FleetServices { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobChild> JobChilds { get; set; }
        public virtual DbSet<JobQuotationApproval> JobQuotationApprovals { get; set; }
        public virtual DbSet<ModuleCategory> ModuleCategories { get; set; }
        public virtual DbSet<ModuleForm> ModuleForms { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<RegionalOffice> RegionalOffices { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RolesToUser> RolesToUsers { get; set; }
        public virtual DbSet<Tender> Tenders { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<VendorQuotation> VendorQuotations { get; set; }
        public virtual DbSet<VendorQuotationChild> VendorQuotationChilds { get; set; }
        public virtual DbSet<VendorQuotationDetail> VendorQuotationDetails { get; set; }
        public virtual DbSet<VendorsBusinessNature> VendorsBusinessNatures { get; set; }
        public virtual DbSet<VendorsOrgType> VendorsOrgTypes { get; set; }
        public virtual DbSet<ExecutedJob> ExecutedJobs { get; set; }
        public virtual DbSet<TenderChild> TenderChilds { get; set; }
        public virtual DbSet<TenderDetail> TenderDetails { get; set; }
    }
}
