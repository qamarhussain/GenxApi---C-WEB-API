using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Linq.Expressions;

namespace GENXAPI.Repisitory
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext db;

        public Repository(DbContext _db)
        {
            db = _db;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().AsNoTracking().ToList();
        }

        public int GetTotalNoOfTender()
        {
            var query = db.Database.SqlQuery<TEntity>("SELECT * FROM Tender INNER JOIN TenderChild ON Tender.Id = TenderId WHERE TenderChild.VehicleId IS NULL").ToList();
            var count = query.Count();
            return count;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return db.Set<TEntity>().AsNoTracking().Where(predicate);
        }

        public TEntity Get(object Id)
        {
            return db.Set<TEntity>().Find(Id);
        }

        public IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = db.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty).AsNoTracking();
            }
            return query;
        }

        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }
        
        public void AddRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            db.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().RemoveRange(entities);
        }

        public void Remove(object Id)
        {
            TEntity entity = db.Set<TEntity>().Find(Id);
            this.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            db.Entry<TEntity>(entity).State = EntityState.Modified;
        }
    }
}
