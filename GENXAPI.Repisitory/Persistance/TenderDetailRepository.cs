using GENXAPI.Repisitory.Model;

namespace GENXAPI.Repisitory
{
    public class TenderDetailRepository : Repository<TenderDetail>, ITenderDetailRepository
    {
        public Entities context
        {
            get
            {
                return db as Entities;
            }
        }

        public TenderDetailRepository(Entities _db)
            : base(_db)
        {

        }

    }
}
