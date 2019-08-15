using GENXAPI.Repisitory.Model;

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
                
    }
}
