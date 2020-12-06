using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApi.DAL.Repository
{
    public interface IRepository<T>
    {
        Task<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<int> AddAsync(T entity);
        T GetAsync(int id, string includeProperties = "", Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<int> Update(T entity);
        Task Delete(T entity);
        IQueryable<T> GetAllAsync(bool disableTracking = true, string includeProperties = "",
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}
