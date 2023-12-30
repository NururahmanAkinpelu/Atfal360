using Atfal360.Context;
using Atfal360.Entities;
using Atfal360.Interface.Repositories;
using System.Linq.Expressions;

namespace Atfal360.Implementation.Repositories
{
    public class RegionRepository : BaseRepository<Region>, IRegionRepository
    {
        public RegionRepository(ApplicationContext context)
        {
            _context = context;
        }




    }
}
