using Atfal360.Contract;
using System.Linq.Expressions;

namespace Atfal360.Interface.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task<T> Get(Expression<Func<T, bool>> expression);

        Task<IList<T>> GetAll();

        Task<IList<T>> GetByExpression(Expression<Func<T, bool>> expression);
    }
}
