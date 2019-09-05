using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class JobQuotationApprovalRepository : Repository<JobQuotationApproval>, IJobQuotationApprovalRepository
    {
        public Entities context
        {
            get
            {
                return db as Entities;
            }
        }

        public JobQuotationApprovalRepository(Entities _db)
            : base(_db)
        {

        }

        public IList<DropdownListDto> GetJobsKeyPairByContract(int contractId)
        {
            var result = Find(m => m.ContractId == contractId).GroupBy(car => car.JobNo).Select(g => g.First()).ToList().Select(r =>
           new DropdownListDto
           {
               Value = r.JobId.ToString(),
               Text = r.JobNo
           });
            return result.ToList();
        }

    }
}
