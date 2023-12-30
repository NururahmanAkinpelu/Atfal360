using Atfal360.Entities;
using System.Linq.Expressions;

namespace Atfal360.Interface.Repositories
{
    public interface IRegionRepository : IBaseRepository<Region>
    {
       /* Task<Region> GetRegionDetails(Expression<Func<Region, bool>> expression);
        Task<IList<Region>> GetRegionsDetails(Expression<Func<Region, bool>> expression);*/
    }
}
