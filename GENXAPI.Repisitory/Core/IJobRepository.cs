using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENXAPI.Repisitory
{
    public interface IJobRepository : IRepository<Job>
    {
        IList<DropdownListDto> GetJobsKeyPairByContract(int contractId);
        IList<DropdownListDto> GetJobsKeyPairByContractIdWithoutStatus(int contractId);
        IList<DropdownListDto> GetExecutedJobsKeyPairByContractId(int contractId);
    }
}
