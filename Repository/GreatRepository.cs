using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using great_challenge.Abstract;
using great_challenge.Models;
using System;

namespace great_challenge.Repository
{
    public class GreatRepository<T> : IGreatRepository<T> where T : class
    {
        private readonly greatContext _context;
        private readonly DbSet<T> _dbSet;

        public GreatRepository(greatContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task Create(T obj)
        {
            _dbSet.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Find(long id) => await _dbSet.FindAsync(id);

        public async Task<T> Find(Expression<Func<T, bool>> predicate) => await _dbSet.FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<T>> GetAll() => await _dbSet.ToListAsync();

        public async Task Delete(T obj)
        {
            _dbSet.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T obj)
        {
            _dbSet.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}