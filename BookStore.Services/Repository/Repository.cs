using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Model;
using System.Data.Entity;
using BookStore.Model.Generated;

namespace BookStore.Services.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {

        private readonly BookStoreDB _dbContext;

        public Repository(BookStoreDB dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual IList<T> Query()
        {
            return _dbContext.Set<T>().ToList();
        }

        public virtual IList<T> Filter(Func<T, bool> predicate)
        {
            return _dbContext.Set<T>()
                   .Where(predicate)
                   .ToList();
        }

        public bool Upsert(T entity)
        {
            if (entity.Id > 0)
            {
                // for updateing
                _dbContext.Entry(entity).State = EntityState.Modified;
               return _dbContext.SaveChanges() > 0;
            }
            // for inserting
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            if (entity != null)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
                return _dbContext.SaveChanges() > 0;
            }

            return false;

        }

    }
}