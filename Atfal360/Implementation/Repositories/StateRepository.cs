using Atfal360.Context;
using Atfal360.Entities;
using Atfal360.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Atfal360.Implementation.Repositories
{
    public class StateRepository : BaseRepository<State>, IStateRepository
    {
        public StateRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<State> GetStateDetails(Expression<Func<State, bool>> expression)
        {
            var state = await _context.State.Include(r => r.Region).FirstOrDefaultAsync(expression);
            return state;
        }

        public async Task<IList<State>> GetStatesDetails(Expression<Func<State, bool>> expression)
        {
            var states = await _context.State.Include(r => r.Region).Where(expression).ToListAsync();
            return states;
        }
    }
}
