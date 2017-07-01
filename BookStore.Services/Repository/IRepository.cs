using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookStore.Services.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(int id);
        IList<T> Query();
        IList<T> Filter(Func<T, bool> predicate);
        bool Upsert(T entity);
        bool Delete(int id);
        
    }
   
}