using Atfal360.Context;
using Atfal360.Entities;
using Atfal360.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Atfal360.Implementation.Repositories
{
    public class MuqamiRepository : BaseRepository<Muqami>, IMuqamiRepository
    {
        public MuqamiRepository(ApplicationContext context) 
        {
            _context = context;
        }


        public async Task<Muqami> GetMuqamiDetails(Expression<Func<Muqami, bool>> expression)
        {
            var muqami = await _context.Muqami.Include(d => d.Dila).ThenInclude(s => s.State).ThenInclude(r => r.Region).FirstOrDefaultAsync(expression);
            return muqami;
        }

        public async Task<IList<Muqami>> GetMuqamisDetails(Expression<Func<Muqami, bool>> expression)
        {
            var muqamis = await _context.Muqami.Include(d => d.Dila).ThenInclude(s => s.State).ThenInclude(r => r.Region).Where(expression).ToListAsync();
            return muqamis;
        }

    }
}
