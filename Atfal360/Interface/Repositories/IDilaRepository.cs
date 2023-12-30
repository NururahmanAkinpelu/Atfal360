using Atfal360.Entities;
using System.Linq.Expressions;

namespace Atfal360.Interface.Repositories
{
    public interface IDilaRepository : IBaseRepository<Dila>
    {
        Task<Dila> GetDilaDetails(Expression<Func<Dila, bool>> expression);
        Task<IList<Dila>> GetDilasDetails(Expression<Func<Dila, bool>> expression);
    }
}
