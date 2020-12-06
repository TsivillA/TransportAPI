using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApi.Common.Enums;
using WebApi.DAL.Models;

namespace WebApi.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly TransportDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(TransportDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<int> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();

            return entity.Id;
        }

        public async Task Delete(T entity)
        {
            entity.EntityStatus = EntityStatus.Deleted;
            await Update(entity);
        }

        public IQueryable<T> GetAllAsync(bool disableTracking = true, string includeProperties = "",
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            if (include != null)
            {
                query = include(query);
            }

            foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            return query.Where(x => x.EntityStatus == EntityStatus.Active);
        }

        public T GetAsync(int id, string includeProperties = "", Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _dbSet;
            foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (include != null)
            {
                query = include(query);
            }

            var item = query.FirstOrDefault(x => x.Id == id);

            return item == null ? null
                : IsDeleted(item) ? null : item;
        }

        public async Task<int> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Update(entity);
            await SaveAsync();

            return entity.Id;
        }

        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool IsDeleted(T item)
        {
            return item.EntityStatus == EntityStatus.Deleted;
        }
    }
}
