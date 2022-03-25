using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Interfaces.Persistence;
using TBCInsiders.Management.Infrastructure.Persistence.Data;

namespace TBCInsiders.Management.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext _context;
        private DbSet<T> set;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            set = _context.Set<T>();
        }
        public void Add(T entity)
        {
            set.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            set.AddRange(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await set.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await set.CountAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await set.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await set.FindAsync(id);
        }

        public IQueryable<T> QueryAll()
        {
            return set.AsNoTracking().AsQueryable();
        }

        public async Task<T> UpdateAsync(T entity,int key)
        {
            try
            {
                var existing = await _context.Set<T>().FindAsync(key);


                if (existing != null)
                {
                    _context.Entry(existing).CurrentValues.SetValues(entity);
                }
                return existing;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Remove(int key)
        {
            var entity = set.Find(key);
            Remove(entity);
        }

        public void Remove(T entity)
        {
            set.Remove(entity);
        }

    }
}
