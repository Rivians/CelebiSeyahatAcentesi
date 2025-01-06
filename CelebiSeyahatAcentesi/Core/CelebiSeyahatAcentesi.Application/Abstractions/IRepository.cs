using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Abstractions
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>> filter);
        Task<IQueryable<T>> GetAllQueryableAsync();  // buraya list türünde değilde iqueryable türünde sorgu ekledik.
        Task<T> GetByIdAsync(string id);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(List<T> entity);
        Task<T?> GetByFilterAsync(Expression<Func<T,bool>> filter);
    }
}
