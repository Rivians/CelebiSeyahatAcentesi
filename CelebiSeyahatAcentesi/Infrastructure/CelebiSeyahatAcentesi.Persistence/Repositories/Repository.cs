using CelebiSeyahat.Application.Abstractions;
using CelebiSeyahat.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CelebiSeyehatDbContext _context;
        public Repository(CelebiSeyehatDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(T entity)
        {
            _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(List<T> entity)
        {
            _context.Set<List<T>>().AddRangeAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(List<T> entity)
        {
            _context.Set<List<T>>().RemoveRange(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

		public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
		{
			return await _context.Set<T>().Where(filter).ToListAsync();
		}

		public async Task<IQueryable<T>> GetAllQueryableAsync()
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
