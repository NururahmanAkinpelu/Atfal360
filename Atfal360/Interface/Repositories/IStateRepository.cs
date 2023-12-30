using Atfal360.Entities;
using System.Linq.Expressions;

namespace Atfal360.Interface.Repositories
{
    public interface IStateRepository : IBaseRepository<State>
    {
        Task<State> GetStateDetails(Expression<Func<State, bool>> expression);
        Task<IList<State>> GetStatesDetails(Expression<Func<State, bool>> expression);
    }
}
