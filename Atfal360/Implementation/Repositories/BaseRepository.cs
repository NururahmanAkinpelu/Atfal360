using Atfal360.Context;
using Atfal360.Contract;
using Atfal360.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Atfal360.Implementation.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        protected ApplicationContext _context;

        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(expression);
            return result;
        }

        public async Task<IList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IList<T>> GetByExpression(Expression<Func<T, bool>> expression)
        {
            var result = await _context.Set<T>().Where(expression).ToListAsync();
            return result;
        }
    }
}
