using System;
using System.Collections.Generic;
using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;
using System.Linq;

namespace GENXAPI.Repisitory
{
    public class TenderRepository : Repository<Tender>, ITenderRepository
    {
        public Entities context
        {
            get
            {
                return db as Entities;
            }
        }

        public TenderRepository(Entities _db)
            : base(_db)
        {

        }

        public IList<DropdownListDto> GetContractKeyPair(int CompanyId, int BusinessUnitId, int CustomerId)
        {
            var result = Find(m => m.ProceedStatus != (byte)TenderUtility.ContractCancelState && m.CustomerId == CustomerId && m.CompanyId == CompanyId && m.BusinessUnitId == BusinessUnitId && m.Customer.Type == "1").Select(r =>
          new DropdownListDto
          {
              Value = r.Id.ToString(),
              Text = r.TenderNo
          });
            return result.ToList();
        }

        public IList<DropdownListDto> GetContractKeyPairForJob(int CustomerId)
        {
            var result = Find(m => m.StatusId == (byte)Status.Active && m.CustomerId == CustomerId && (m.ProceedStatus >= (byte)TenderUtility.ContractApprovedState && m.ProceedStatus != (byte)TenderUtility.ContractCancelState)).Select(r =>
        new DropdownListDto
        {
            Value = r.Id.ToString(),
            Text = r.TenderNo
        });
            return result.ToList();
        }
    }
}
