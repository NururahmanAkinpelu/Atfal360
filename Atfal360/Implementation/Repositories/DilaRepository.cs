using Atfal360.Context;
using Atfal360.Entities;
using Atfal360.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Atfal360.Implementation.Repositories
{
    public class DilaRepository : BaseRepository<Dila>, IDilaRepository
    {
        public DilaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Dila> GetDilaDetails(Expression<Func<Dila, bool>> expression)
        {
            var dila = await _context.Dila.Include(s => s.State).ThenInclude(r => r.Region).FirstOrDefaultAsync(expression);
            return dila;
        }

        public async Task<IList<Dila>> GetDilasDetails(Expression<Func<Dila, bool>> expression)
        {
            var dilas = await _context.Dila.Include(s => s.State).ThenInclude(r => r.Region).Where(expression).ToListAsync();
            return dilas;
        }
    }
}
