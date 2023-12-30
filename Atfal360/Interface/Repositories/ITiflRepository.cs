using Atfal360.Entities;
using Atfal360.Wrapper;
using System.Linq.Expressions;

namespace Atfal360.Interface.Repositories
{
    public interface ITiflRepository : IBaseRepository<Tifl>
    {
        Task<Tifl> GetTiflDetails(Expression<Func<Tifl, bool>> expression);
        Task<IList<Tifl>> GetAtfalDetails(Expression<Func<Tifl, bool>> expression);
    }
}
