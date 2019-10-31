using GENXAPI.Repisitory.Core;
using GENXAPI.Repisitory.Model;

namespace GENXAPI.Repisitory.Persistance
{
    public class JobExecutedTrackingRepository : Repository<JobExecutedTracking>, IJobExecutedTrackingRepository
    {
        public Entities context
        {
            get
            {
                return db as Entities;
            }
        }

        public JobExecutedTrackingRepository(Entities _db)
            : base(_db)
        {

        }
    }
}
