using GENXAPI.Repisitory.Model;
using GENXAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public Entities context
        {
            get
            {
                return db as Entities;
            }
        }

        public JobRepository(Entities _db)
            : base(_db)
        {

        }

        public IList<DropdownListDto> GetJobsKeyPairByContract(int contractId)
        {
            var result = Find(m => m.TenderId == contractId && m.JobStatus == (byte)Status.Active).Select(r =>
           new DropdownListDto
           {
               Value = r.JobId.ToString(),
               Text = r.JobNo
           });
            return result.ToList();
        }
        public IList<DropdownListDto> GetJobsKeyPairByContractIdWithoutStatus(int contractId)
        {
            var result = Find(m => m.TenderId == contractId).Select(r =>
          new DropdownListDto
          {
              Value = r.JobId.ToString(),
              Text = r.JobNo
          });
            return result.ToList();
        }

    }
}
