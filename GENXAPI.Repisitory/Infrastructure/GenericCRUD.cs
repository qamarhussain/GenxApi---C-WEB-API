using GENXAPI.Repisitory.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GENXAPI.Repisitory
{
    public abstract class GenericCRUD<TEntity> where TEntity : class
    {
        protected Entities conn;

        protected GenericCRUD()
        {
            if (conn == null)
            {
                conn = new Entities();
            }
        }

        //Add new Entity
        public virtual void Create(TEntity obj)
        {
            conn.Entry(obj).State = EntityState.Added;
            conn.SaveChanges();
        }
        //Update Entity
        public virtual void Update(TEntity obj)
        {
            conn.Entry(obj).State = EntityState.Modified;
            conn.SaveChanges();
        }

        //Delete Entity
        public virtual void Delete(int id)
        {
            var dbObj = conn.Set<TEntity>().Find(id);
            conn.Entry(dbObj).State = EntityState.Deleted;
            conn.SaveChanges();
        }
        //Get Entity by Id
        public virtual TEntity Get(int id)
        {
            return conn.Set<TEntity>().Find(id);
        }

        //Get All Entities
        public virtual IEnumerable<TEntity> GetAll()
        {
            return conn.Set<TEntity>().AsNoTracking().ToList();
        }

        //Get All Entities
        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return conn.Set<TEntity>().AsNoTracking().Where(predicate);
        }

        public IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = conn.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

    }
}
