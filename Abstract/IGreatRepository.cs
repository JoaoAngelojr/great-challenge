using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace great_challenge.Abstract
{
    public interface IGreatRepository<T> where T : class
    {
        Task Create(T obj);
        Task<IEnumerable<T>> GetAll();
        Task<T> Find (Expression<Func<T, bool>> predicate);
        Task<T> Find(long id);
        Task Delete(T obj);
        Task Update(T obj);
    }
}