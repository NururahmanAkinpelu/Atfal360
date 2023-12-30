using Atfal360.Context;
using Atfal360.Entities;
using Atfal360.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Atfal360.Implementation.Repositories
{
    public class TiflRepository : BaseRepository<Tifl>, ITiflRepository
    {
        public TiflRepository(ApplicationContext context) 
        {
            _context = context;
        }


        public async Task<IList<Tifl>> GetAtfalDetails(Expression<Func<Tifl, bool>> expression)
        {
            var tifl = await _context.Tifl.Include(m => m.Muqami).ThenInclude(d => d.Dila).ThenInclude(s => s.State).ThenInclude(r => r.Region).Where(expression).ToListAsync();
            return tifl;
        }

        public async Task<Tifl> GetTiflDetails(Expression<Func<Tifl, bool>> expression)
        {
            var tifl = await _context.Tifl.Include(m => m.Muqami).ThenInclude(d => d.Dila).ThenInclude(s => s.State).ThenInclude(r => r.Region).FirstOrDefaultAsync(expression);
            return tifl;
        }
    }
}
